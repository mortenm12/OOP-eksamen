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
        public uint NextUserId 
        {
            get
            {
                return NextUserId++;
            }
            private set; 
        }

        /// <summary>
        /// Return the next Product Id.
        /// </summary>
        public uint NextProductId {
            get
            {
                return NextProductId++;
            }
            private set;
        }

        /// <summary>
        /// Return the next Transaction Id.
        /// </summary>
        public uint NextTransactionId
        {
            get
            {
                return NextTransactionId++;
            }
            private set;
        }
    }
}
