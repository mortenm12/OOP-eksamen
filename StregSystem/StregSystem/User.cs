using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem
{
    class User : IComparable
    {
        /// <summary>
        /// The ID number of the User.
        /// </summary>
        public readonly long Id;

        /// <summary>
        /// The FirstName of the User.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// The LastName of the User.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// The UserName of the User.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// The Email adress og the User.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The money balance of the User.
        /// </summary>
        public int Balance { get; set; }


        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Email;
        }

        public override bool Equals(object obj)
        {
            User p = obj as User;
            return this.Id == p.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
