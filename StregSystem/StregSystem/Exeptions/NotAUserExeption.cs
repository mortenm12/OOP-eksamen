using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Exeptions
{
    class NotAUserExeption : Exception
    {
        public string UserName { get; set; }

        public NotAUserExeption()
        {


        }

        public NotAUserExeption(string username)
        {
            UserName = username;
        }

    
    }
}
