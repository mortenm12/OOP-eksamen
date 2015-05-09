using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Products;

namespace StregSystem.Exeptions
{
    class InsufficientCreditsException : Exception
    {
        public User TheUser { get; set; }

        public Product TheProduct { get; set; }

        public String Fail { get; set; }

        public InsufficientCreditsException(User theUser, Product theProduct, string fail)
        {
            TheUser = theUser;
            TheProduct = theProduct;
            Fail = fail;
        }

    }
}
