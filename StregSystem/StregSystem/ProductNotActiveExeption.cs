using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem
{
    class ProductNotActiveExeption : Exception
    {
        public User TheUser { get; set; }

        public Product TheProduct { get; set; }

        public String Fail { get; set; }

        public ProductNotActiveExeption(User theUser, Product theProduct, string fail)
        {
            TheUser = theUser;
            TheProduct = theProduct;
            Fail = fail;
        }
    }
}
