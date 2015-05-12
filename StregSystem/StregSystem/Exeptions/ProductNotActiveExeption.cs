using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Products;

namespace StregSystem.Exeptions
{
    /// <summary>
    /// An Exeption there is throw when a user try to buy a product there isn't active.
    /// </summary>
    public class ProductNotActiveExeption : Exception
    {
        /// <summary>
        /// The products id
        /// </summary>
        public uint ProductId { get; set; }

        /// <summary>
        /// The fail messege.
        /// </summary>
        public String Fail { get; set; }

        public ProductNotActiveExeption(uint id, string fail)
        {
            ProductId = id;
            Fail = fail;
        }
    }
}
