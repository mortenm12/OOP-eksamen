using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Products;

namespace StregSystem.Exeptions
{
    class ProductNotActiveExeption : Exception
    {
        public uint ProductId { get; set; }

        public String Fail { get; set; }

        public ProductNotActiveExeption(uint id, string fail)
        {
            ProductId = id;
            Fail = fail;
        }
    }
}
