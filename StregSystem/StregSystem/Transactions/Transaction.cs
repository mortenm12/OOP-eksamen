using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Transactions
{
    abstract class Transaction
    {
        public uint TransactionId;

        private User theUser { get; set; }
        public User TheUser
        {
            get
            {
                return theUser;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("The User can't be NULL.");
                else
                    theUser = value;
            }
        }

        private DateTime date { get; set; }
        public DateTime Date 
        {
            get
            {
                return date;
            }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("The Date can't be NULL.");
                else
                    date = value;
            } 
        }

        public int Amount { get; set; }

        public abstract void Execute();


        public abstract string FullString();
    }
}
