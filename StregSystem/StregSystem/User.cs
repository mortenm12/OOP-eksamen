using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StregSystem
{
    public class User //: IComparable
    {
        /// <summary>
        /// The ID number of the User.
        /// </summary>
        public uint Id{get;set;}

        /// <summary>
        /// The FirstName of the User.
        /// </summary>
        private string firstName { get; set; }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("You Can't set Firstname to NULL");
                firstName = value;
            }
        }


        /// <summary>
        /// The LastName of the User.
        /// </summary>
        private string lastName { get; set; }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("You Can't set Firstname to NULL");
                else
                    lastName = value;
            }
        }

        /// <summary>
        /// The UserName of the User.
        /// </summary>

        private string userName;    //jeg ved ikke hvorfor jeg skal lave en privat her, mens alle andre steder ser det ud til at virke.
        public string UserName 
        {
            get
            {
                return this.userName;
            }
            set 
            {
                Regex UserNameCheck = new Regex(@"[a-z0-9_]+$"); //Jeg har brugt MSDN til at forstå og bruge regular expression
                if (UserNameCheck.IsMatch(value))
                {
                    this.userName = value;
                }
                else
                {
                    Console.WriteLine("fejl");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// The Email adress og the User.
        /// </summary>
        private string email { get; set; }
        public string Email {
            get
            {
                return email;
            }
            set
            {
                Regex EmailCheck = new Regex(@"[a-zA-Z0-9.-_]+@[a-zA-Z0-9][a-zA-Z0-9.-]+[a-zA-Z0-9]+.[a-zA-Z0-9]+$");
                if (EmailCheck.IsMatch(value))
                {
                    email = value;
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
            return UserName+" "+FirstName + " " + LastName + " " + ((double)Balance)/100 + "Dkk";
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
            Id = ID.NextUserId();
        }

    }
}
