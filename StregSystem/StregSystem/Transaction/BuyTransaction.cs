using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Products;
using StregSystem.Exeptions;

namespace StregSystem.Transaction
{
    class BuyTransaction : Transaction
    {
        /// <summary>
        /// The product which is bought.
        /// </summary>
        public Product TheProduct { get; set; }

        /// <summary>
        /// The price on the product at the time it got bought.
        /// </summary>
        public int Amount { get; set; }

        public override string ToString()
        {
            return "Product bought:" + TheProduct + " Price:" + Amount + "Dkk User:" + TheUser + " Date:" + Date + " TransactionID:" + TransactionId;
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
                throw new ProductNotActiveExeption(TheUser, TheProduct, "The product isn't active.");
            }
        }

        public BuyTransaction()
        {
            TransactionId = ID.NextTransactionId;
            Date = DateTime.Now;
        }
    }
}
