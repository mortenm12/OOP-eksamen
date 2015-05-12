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
        /// <summary>
        /// The list of all the users.
        /// </summary>
        public List<User> UserList = new List<User>();

        /// <summary>
        /// The list of all the products.
        /// </summary>
        public List<Product> ProductList = new List<Product>();

        /// <summary>
        /// THe list of all the executed transactions.
        /// </summary>
        public List<Transaction> ExecutedTransactions = new List<Transaction>();

        /// <summary>
        /// Makes a transaction for buy pruduct and calls execute on it.
        /// </summary>
        /// <param name="TheUser">The user that buóught the pruduct.</param>
        /// <param name="TheProduct"> the product the user bought.</param>
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

        /// <summary>
        /// Makes a transaction for adding credits.
        /// </summary>
        /// <param name="user">The user thats should have the credits.</param>
        /// <param name="amount">The amount of credits the user must get in øre.</param>
        public void AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction InsertCash = new InsertCashTransaction()
            {
                Amount = amount,
                TheUser = user,
            };
            ExecuteTransaction(InsertCash);
        }

        /// <summary>
        /// Mekes sure to execute the transaction and it is done correctly it is wrote to the log.
        /// </summary>
        /// <param name="transaction">The transaction thats wants executed.</param>
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

        /// <summary>
        /// Find and returns a pruduct base on its id.
        /// </summary>
        /// <param name="productId">the id that should parse to at product.</param>
        /// <returns>returns a product based on its id.</returns>
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

        /// <summary>
        /// Find and returns a user, based on it's username.
        /// </summary>
        /// <param name="userName">The username ther user should be finded on.</param>
        /// <returns>returns a user.</returns>
        public User GetUser(string userName)
        {
            if (UserList.Exists(x => x.UserName == userName))
                return UserList.Find(x => x.UserName == userName);
            else
            {
                throw new NotAUserExeption(userName);
            }
        }

        /// <summary>
        /// Find and returns a list on all the transaction that could be found on the user, in order of the newest.
        /// </summary>
        /// <param name="user">The user the transaction is seached for.</param>
        /// <param name="count">the numbers of transaction that should be returned.</param>
        /// <returns></returns>
        public List<Transaction> GetTransactionList(User user, int count)
        {
            List<Transaction> UserTransactionList = ExecutedTransactions.FindAll(x => x.TheUser == user).ToList();
            return UserTransactionList.OrderByDescending(x => x.Date).Take(count).ToList();
        }

        /// <summary>
        /// Find and returns all the active pruducts.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetActiveProducts()
        {
            return ProductList.FindAll(x => x.Active == true).ToList();
        }

        /// <summary>
        /// Reads a file and saves it to the productlist.
        /// </summary>
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

            ID.ProductId = ProductList[ProductList.Count - 1].ProductID;
        }

        /// <summary>
        /// Reads a file and fill out the userlist.
        /// </summary>
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
            ID.UserId = UserList[UserList.Count - 1].Id;
        }

        /// <summary>
        /// Reads a file and fill out the transaction list.
        /// </summary>
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
                    throw new NotValidTextExeption(line);
                }
            }
            file.Close();

            int last = ExecutedTransactions.Count()-1;
            if(last <= 0)
                ID.TransactionId = 0;
            else
                ID.TransactionId = ExecutedTransactions[last].TransactionId;
        }

        public StregSystem()
        {
            FillProductList();
            FillUserList();
            FillTransactionsList();
        }
    }
}
