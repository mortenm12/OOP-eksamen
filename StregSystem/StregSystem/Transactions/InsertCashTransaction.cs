﻿using System;
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
            return "Insert cash: " + Amount +"Dkk"+ " " + TheUser + " Date:" + Date +" ID:"+ TransactionId;
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

        public override string FullString()
        {
            return "IC," + TransactionId + "," + TheUser.UserName + "," + Amount + "," + Date;
        }
    }
}
