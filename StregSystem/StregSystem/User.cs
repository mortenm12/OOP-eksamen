using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StregSystem
{
    class User //: IComparable
    {
        /// <summary>
        /// The ID number of the User.
        /// </summary>
        public long Id{get;set;}

        /// <summary>
        /// The FirstName of the User.
        /// </summary>
        public string FirstName
        {
            get
            {
                return FirstName;
            }
            set
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
            get
            {
                return LastName;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("You Can't set Firstname to NULL");
            }
        }

        /// <summary>
        /// The UserName of the User.
        /// </summary>
        public string UserName 
        {
            get
            {
                return UserName;
            }
            set 
            {
                Regex UserNameCheck = new Regex(@"[a-z0-9_]$"); //Jeg har brugt MSDN til at forstå og bruge regular expression
                if (UserNameCheck.IsMatch(value))
                {
                    UserName = value;
                }
                else
                {
                    //smid en fejl
                }
            }
        }

        /// <summary>
        /// The Email adress og the User.
        /// </summary>
        public string Email {
            get
            {
                return Email;
            }
            set
            {
                Regex EmailCheck = new Regex(@"[a-zA-Z0-9.-_]@[a-zA-Z0-9][a-zA-Z0-9.-][a-zA-Z0-9].[a-zA-Z0-9]$");
                if (EmailCheck.IsMatch(value))
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


        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Email;
        }

        public override bool Equals(object obj)
        {
            User other = obj as User;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public int CompareTo(User other)
        {
            if (this.Id > other.Id)
                return 1;
            else if (this.Id < other.Id)
                return -1;
            else return 0;
        }
        public User()
        {
            Id = ID.NextUserId;
        }

       
    }
}
