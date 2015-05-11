using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Products;
using StregSystem.Transactions;
using System.IO;
using StregSystem.Exeptions;


namespace StregSystem
{
    class StregSystem
    {
        
        public List<User> UserList = new List<User>();
        public List<Product> ProductList = new List<Product>();
        public List<Transaction> ExecutedTransactions = new List<Transaction>();

        public void BuyProduct(User TheUser, Product TheProduct)
        {
            
           BuyTransaction productbuy = new BuyTransaction()
            {
                Amount = TheProduct.Price,
                TheUser = TheUser,
                TheProduct = TheProduct,
            };

           ExecuteTransaction(productbuy);
        }

        public void AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction InsertCash = new InsertCashTransaction()
            {
                Amount = amount,
                TheUser = user,
            };
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            System.IO.StreamWriter file = new StreamWriter("..\\..\\TransactionsLog.txt",true); //Læst om skrivning til filer på MSDN
            try
            {
                transaction.Execute();

                file.WriteLine(transaction.FullString());

            }
            catch (InsufficientCreditsException e)
            {
                throw new InsufficientCreditsException(e.TheUser,e.TheProduct,e.Fail);
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }

        public Product GetProduct(uint productId)
        {
            if (ProductList.Exists(x => x.ProductID == productId))
            {
                return ProductList.Find(x => x.ProductID == productId);
            }
            else
            {
                throw new ProductNotActiveExeption(productId, "The product couldn't be fount.");
                
            }
        }

        public User GetUser(string userName)
        {
            if (UserList.Exists(x => x.UserName == userName))
                return UserList.Find(x => x.UserName == userName);
            else
            {
#warning               throw new NotAUserExeption();
                return new User(); //ellers får jeg en fejl om at ikke alle veje fører til en return
            }
        }

        public List<Transaction> GetTransactionList(User user, int count)
        {
            List<Transaction> UserTransactionList = ExecutedTransactions.FindAll(x => x.TheUser == user).ToList();
            UserTransactionList.OrderBy(x => x.Date).Reverse();
            return UserTransactionList.Take(count).ToList();
        }

        public List<Product> GetActiveProducts()
        {
            return ProductList.FindAll(x => x.Active == true).ToList();
        }

        public void FillProductList()
        {
            System.IO.StreamReader file = new StreamReader("..\\..\\products.csv", System.Text.Encoding.Default);  // læst om læsning af filer på MSDN, og for at få æøå ind brugte jeg eksemplet fra http://www.eksperten.dk/spm/874431
            string line;
            char[] parser ={';',';',';',';'};
            line = file.ReadLine(); //for at fjerne den første linje.
            while ((line = file.ReadLine()) != null)
            {
                string[] productInfo = line.Split(parser); //lært på MSDN
                
                Console.WriteLine(productInfo[1]);//skal fjernes, er kun til debug

                Product newproduct = new Product()
                     {
                         ProductID = Convert.ToUInt32(productInfo[0]),
                         Price = Convert.ToInt32(productInfo[2]),
                         Active = (productInfo[3] == "1" ? true : false),
                         CanBeBoughtOnCredit = false,
                     };

                if(productInfo[1].StartsWith("<"))
                {
                    char[] parserh = { '<','>', '<','>' };
                   string[] namesplit = productInfo[1].Split(parserh);
                   newproduct.Name = namesplit[2];
                }
                else
                {
                    newproduct.Name = productInfo[1];
                }

                ProductList.Add(newproduct);
            }
            file.Close();
        }

        public void FillUserList()
        {
            System.IO.StreamReader file = new StreamReader("..\\..\\UserList.txt");
            string line;
            char[] parser = { ',', ',', ',', ',', ',' };
            line = file.ReadLine(); //for at fjerne den første linje.
            while ((line = file.ReadLine()) != null)
            {
                string[] userInfo = line.Split(parser);
                UserList.Add(new User()
                    {
                        Id = Convert.ToUInt32(userInfo[0]),
                        UserName = userInfo[1],
                        FirstName = userInfo[2],
                        LastName = userInfo[3],
                        Email = userInfo[4],
                        Balance = Convert.ToInt32(userInfo[5])
                    }
                    );
            }
            file.Close();
        }

        public void FillTransactionsList()
        {
            System.IO.StreamReader file = new StreamReader("..\\..\\TransactionsLog.txt");
            string line;
            char[] BTparser = { ',', ',', ',', ',', ',' };
            char[] ICparser = { ',', ',', ',', ',' };
            line = file.ReadLine(); //for at fjerne den første linje.
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("BT"))
                {
                    string[] transactionsInfo = line.Split(BTparser);
                    ExecutedTransactions.Add(new BuyTransaction()
                        {
                            TransactionId = Convert.ToUInt32(transactionsInfo[1]),
                            TheUser = GetUser(transactionsInfo[2]),
                            TheProduct = GetProduct(Convert.ToUInt32(transactionsInfo[3])),
                            Amount = Convert.ToInt32(transactionsInfo[4]),
                            Date = Convert.ToDateTime(transactionsInfo[5])
                        }
                        );
                }
                else if (line.StartsWith("IC"))
                {
                    string[] transactionsInfo = line.Split(ICparser);
                    ExecutedTransactions.Add(new BuyTransaction()
                    {
                        TransactionId = Convert.ToUInt32(transactionsInfo[1]),
                        TheUser = GetUser(transactionsInfo[2]),
                        Amount = Convert.ToInt32(transactionsInfo[3]),
                        Date = Convert.ToDateTime(transactionsInfo[4])
                    }
                        );
                }
                else
                {
#warning            throw new NotValidTextExeption();
                }
            }
            file.Close();
        }

        public StregSystem()
        {
            FillProductList();
            FillUserList();
            FillTransactionsList();
        }
    }
}
