using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Transaction
{
    class Transaction
    {
        public readonly uint TransactionId;

        public User TheUser
        {
            get;
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
            get;
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("The Date can't be NULL.");
                else
                    Date = value;
            } 
        }

        public int Amount { get; set; }

        public virtual void Execute();

        public override string ToString()
        {
            return TransactionId + " " + Amount + " " + Date;
        }

        public Transaction(uint Id)
        {
            TransactionId = Id;
        }
    }
}
