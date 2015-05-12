using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Products;
using StregSystem.Exeptions;

namespace StregSystem.Transactions
{
    class BuyTransaction : Transaction
    {
        /// <summary>
        /// The product which is bought.
        /// </summary>
        public Product TheProduct { get; set; }

        
        public override string ToString()
        {
            return "Product bought:" + TheProduct + " Price:" + (double)Amount/100 + "Dkk User:" + TheUser.UserName + " Date:" + Date + " TransactionID:" + TransactionId;
        }

        public override void Execute()
        {
            if (TheProduct.Active)
            {
                if (TheUser.Balance >= Amount || TheProduct.CanBeBoughtOnCredit)
                {
                    TheUser.Balance -= Amount;
                }
                else
                {
                    throw new InsufficientCreditsException(TheUser, TheProduct,"There isn't enought money on the account.");
                }
            }
            else
            {
                throw new ProductNotActiveExeption(TheProduct.ProductID, "The product isn't active.");
            }
        }

        public BuyTransaction()
        {
            TransactionId = ID.NextTransactionId();
            Date = DateTime.Now;
        }

        /// <summary>
        /// Returns all the info in buy transaction, to use when it is save to a file.
        /// </summary>
        /// <returns>A comma seperated string.</returns>
        public override string FullString()
        {
            return "BT," + TransactionId + "," + TheUser.UserName + "," + TheProduct.ProductID + "," + Amount + "," + Date;
        }
    }
}
