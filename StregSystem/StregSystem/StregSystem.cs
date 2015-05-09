using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Products;
using StregSystem.Transaction;
using System.IO;

namespace StregSystem
{
    class StregSystem
    {


        public void BuyProduct(User TheUser, Product TheProduct)
        {
            
           BuyTransaction productbuy = new BuyTransaction()
            {
                
                Amount = TheProduct.Price,
                TheUser = TheUser,
                TheProduct = TheProduct,
            };

           System.IO.StreamWriter file = new StreamWriter("c:\\TransactionsLog.txt");
           file.WriteLine(productbuy.ToString());
        }
    }
}
