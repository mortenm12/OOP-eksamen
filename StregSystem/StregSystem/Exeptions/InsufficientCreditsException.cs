using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Products;

namespace StregSystem.Exeptions
{
    /// <summary>
    /// An Exeption there is throw when a user don't have enough money to buy a product.
    /// </summary>
   public class InsufficientCreditsException : Exception
    {
        /// <summary>
        /// The user there din't have enougt money.
        /// </summary>
        public User TheUser { get; set; }

        /// <summary>
        /// The product the user try to buy.
        /// </summary>
        public Product TheProduct { get; set; }

        /// <summary>
        /// The fail message.
        /// </summary>
        public String Fail { get; set; }

        public InsufficientCreditsException(User theUser, Product theProduct, string fail)
        {
            TheUser = theUser;
            TheProduct = theProduct;
            Fail = fail;
        }

    }
}
