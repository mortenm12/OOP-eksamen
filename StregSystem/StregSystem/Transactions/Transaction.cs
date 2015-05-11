using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Transactions
{
    class Transaction
    {
        public uint TransactionId;

        public User TheUser
        {
            get
            {
                return TheUser;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("The User can't be NULL.");
                else
                    TheUser = value;
            }
        }

        public DateTime Date 
        {
            get
            {
                return Date;
            }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("The Date can't be NULL.");
                else
                    Date = value;
            } 
        }

        public int Amount { get; set; }

        public virtual void Execute()
        {

        }

        public override string ToString()
        {
            return TransactionId + " " + Amount + " " + Date;
        }

        public abstract string FullString();
    }
}
