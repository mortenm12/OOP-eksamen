using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem
{
    static class ID
    {
        public long NextUserId 
        {
            get
            {
                return NextUserId++;
            }
            private set; 
        }
        public long NextProductId {
            get
            {
                return NextProductId++;
            }
            private set;
        }

    }
}
