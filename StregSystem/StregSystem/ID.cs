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
        /// Return the last User Id.
        /// </summary>
        public static uint UserId { get; set; }


        /// <summary>
        /// Return the last Product Id.
        /// </summary>
        public static uint ProductId { get; set; }

        /// <summary>
        /// Return the last Transaction Id.
        /// </summary>
        public static uint TransactionId { get; set; }

        /// <summary>
        /// Returns the next UserId.
        /// </summary>
        /// <returns></returns>
        public static uint NextUserId()
        {
            UserId++;
            return UserId;
        }

        /// <summary>
        /// Returns the next ProductId.
        /// </summary>
        /// <returns></returns>
        public static uint NextProductId()
        {
            ProductId++;
            return ProductId;
        }

        public static uint NextTransactionId()
        {
            TransactionId++;
            return TransactionId;
        }
    }
}
