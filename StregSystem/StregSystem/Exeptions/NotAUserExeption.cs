using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Exeptions
{
    /// <summary>
    /// An exeption there is throw when the text isn't a username on any user.
    /// </summary>
    public class NotAUserExeption : Exception
    {
        /// <summary>
        /// The username that was't a user.
        /// </summary>
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
