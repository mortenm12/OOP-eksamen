using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Products
{
    class SeasonalProduct : Product
    {
        /// <summary>
        /// THe start Date of the Product.
        /// </summary>
        public DateTime SeasonStartDate { get; set; }

        /// <summary>
        /// The end date of the Product.
        /// </summary>
        public DateTime SeasonEndDate { get; set; }

        /// <summary>
        /// Indicates that a product is in for the season.
        /// </summary>
        public override bool Active
        {
            get
            {
                if (DateTime.Today > SeasonStartDate && DateTime.Today < SeasonEndDate)
                    return true;
                else
                    return false;
            }
            set
            {
                Active = value;
            }
        }
    }
}
