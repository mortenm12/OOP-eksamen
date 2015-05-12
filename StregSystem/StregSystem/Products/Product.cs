using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Products
{
    public class Product
    {
        /// <summary>
        /// The products ID.
        /// </summary>
        public uint ProductID;

        /// <summary>
        /// The Name on the Product.
        /// </summary>
        private string name { get; set; }
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("You Can't set Name to NULL");
                else
                    name = value;
            }
        }

        /// <summary>
        /// The Price on the Product.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Active indecates that a pruduct is buyable at the time.
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// Indicates that a product can be bought even if the User don't have enough money.
        /// </summary>
        public bool CanBeBoughtOnCredit { get; set; }

        public Product()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The product id</param>
        public Product(uint id)
        {
            ProductID = id;
        }

        public override string ToString()
        {
            return "ID: " + ProductID + " " + Name +" "+ ((double)Price / 100) + "Dkk";
        }
    }
}
