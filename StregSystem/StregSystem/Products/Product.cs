using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Products
{
    class Product
    {
        /// <summary>
        /// The products ID.
        /// </summary>
        public readonly uint ProductID;

        /// <summary>
        /// The Name on the Product.
        /// </summary>
        public string Name 
        {
            get
            {
                return Name;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("You Can't set Name to NULL");
                else
                    Name = value;
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

        public Product(uint id)
        {
            ProductID = id;
        }
    }
}
