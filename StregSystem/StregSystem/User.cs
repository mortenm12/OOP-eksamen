using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


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
        public string FirstName
        {
            get;
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("You Can't set Firstname to NULL");
            }
        }


        /// <summary>
        /// The LastName of the User.
        /// </summary>
        public string LastName
        {
            get;
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("You Can't set Lastname to NULL");
            }
        }

        /// <summary>
        /// The UserName of the User.
        /// </summary>
        public string UserName 
        { 
            get; 
            private set
            {
                Regex UserNameCheck = new Regex(@"[a-z0-9_]$"); //Jeg har brugt MSDN til at forstå og bruge regular expression
                if (UserNameCheck.IsMatch(value))
                {
                    UserName = value;
                }
                {
                    //smid en fejl
                }

            }
        }

        /// <summary>
        /// The Email adress of the User.
        /// </summary>
        public string Email 
        { 
            get;
            set
            {
                Regex EmailCheck = new Regex(@"[a-zA-Z0-9.-_]@[a-zA-Z0-9][a-zA-Z0-9.-][a-zA-Z0-9].[a-zA-Z0-9]$"); 
                if(EmailCheck.IsMatch(value))
                {
                    Email = value;
                }
                else
                {
                    //smid en fejl
                }
            } 
        }

        /// <summary>
        /// The money balance of the User.
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// ToString returns FullName and Email adress.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Email;
        }

        /// <summary>
        /// Equals compares two Users on theis ID.
        /// </summary>
        /// <param name="obj">THe object which one is compared to.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            User other = obj as User;
            return this.Id == other.Id;
        }

        /// <summary>
        /// HashCode returns the hashcode on the Users ID.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Compares two user, on theirs ID, which is by the date they get into the system.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(User other)
        {
            if (this.Id > other.Id)
                return 1;
            else if (this.Id < other.Id)
                return -1;
            else return 0;
        }

        public User(long id)
        {
            this.Id = id;
        }

        public User(long id, string firstName, string lastName, string userName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = userName;
        }
    }
}
