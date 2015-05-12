using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StregSystem.Transactions
{
    class InsertCashTransaction : Transaction
    {
        public override string ToString()
        {
            return "Insert cash: " + (double)Amount/100 +" Dkk User:" + TheUser.UserName + " Date:" + Date +" ID:"+ TransactionId;
        }

        public override void Execute()
        {
            TheUser.Balance += Amount;
        }

        public InsertCashTransaction()
        {
            TransactionId = ID.NextTransactionId();
            Date = DateTime.Now;
        }

        /// <summary>
        /// Returns all the info in insert cash transaction, to use when it is save to a file.
        /// </summary>
        /// <returns>A comma seperated string.</returns>
        public override string FullString()
        {
            return "IC," + TransactionId + "," + TheUser.UserName + "," + Amount + "," + Date;
        }
    }
}
