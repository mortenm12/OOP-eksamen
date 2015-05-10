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
        
        List<User> UserList = new List<User>();
        List<Product> ProductList = new List<Product>();
        List<Transaction> ExecutedTransactions = new List<Transaction>();

        public void BuyProduct(User TheUser, Product TheProduct)
        {
            
           BuyTransaction productbuy = new BuyTransaction()
            {
                Amount = TheProduct.Price,
                TheUser = TheUser,
                TheProduct = TheProduct,
            };
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
            try
            {
                transaction.Execute();
                System.IO.StreamWriter file = new StreamWriter("c:\\TransactionsLog.txt");
                file.WriteLine(transaction.ToString());
            }
            catch (InsufficientCreditsException e)
            {
                // skriv fejlen ud til brugeren, der er ikke nok penge på kontoen.
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
                //smid en fejl
                return new Product(); //ellers får jeg en fejl om at ikke alle veje fører til en return
            }
        }

        public User GetUser(string userName)
        {
            if (UserList.Exists(x => x.UserName == userName))
                return UserList.Find(x => x.UserName == userName);
            else
            {
                //smid en fejl
                return new User(); //ellers får jeg en fejl om at ikke alle veje fører til en return
            }
        }

        public List<Transaction> GetTransactionList(User user, int number)
        {
            List<Transaction> UserTransactionList = ExecutedTransactions.FindAll(x => x.TheUser == user).ToList();
            UserTransactionList.OrderBy(x => x.Date).Reverse();
            return UserTransactionList.Take(number).ToList();
        }
    }
}
