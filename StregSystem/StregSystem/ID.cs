using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem
{
    static class ID
    {
        /// <summary>
        /// Return the next User Id.
        /// </summary>
        public static uint NextUserId
        {
            get
            {
                NextUserId++;
                return NextUserId;
            }
            set
            {
                NextUserId = value;
            }
        }

        /// <summary>
        /// Return the next Product Id.
        /// </summary>
        public static uint NextProductId {
            get
            {
                return NextProductId++;
            }
            set
            {
                NextProductId = value;
            }
        }

        /// <summary>
        /// Return the next Transaction Id.
        /// </summary>
        public static uint NextTransactionId
        {
            get
            {
                return NextTransactionId++;
            }
            set
            {
                NextTransactionId = value;
            }
        }
    }
}
