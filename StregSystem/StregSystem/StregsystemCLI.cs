using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Transactions;
using StregSystem.Products;
using System.Threading;
using StregSystem.Exeptions;

namespace StregSystem
{
     class StregsystemCLI : IStregsystemUI
    {
         /// <summary>
         /// The stregsystem that is used.
         /// </summary>
         public StregSystem stregSystem;

         /// <summary>
         /// The bool value that keeps the program opened.
         /// </summary>
         public bool close { get; set; }

         /// <summary>
         /// A constructor for the Conmand Line Interface.
         /// </summary>
         /// <param name="stregsystem"></param>
         public StregsystemCLI(StregSystem stregsystem)
         {
             stregSystem = stregsystem;
         }

         /// <summary>
         /// Write out to the user that a requested user isn't found.
         /// </summary>
         /// <param name="userName">The username that didn't get found.</param>
        public void DisplayUserNotFound(string userName)
        {
            Console.WriteLine(userName + " not found, try again.");
            Console.ReadKey();
        }

         /// <summary>
        /// Write out to the user that a requested product, isn't found.
         /// </summary>
         /// <param name="id">The id that didn't get found.</param>
        public void DisplayProductNotFound(uint id)
        {
            Console.WriteLine("ID: " + id + " not found, try again.");
            Console.ReadKey();
        }

         /// <summary>
        /// Write out to the user the info about the requested user.
         /// </summary>
         /// <param name="user">the user which info is gonna be printed.</param>
        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.ToString());

            if (user.Balance < 5000)
            {
                Console.WriteLine("Your balance is less than 50 Dkk.");
            }

            foreach (Transaction element in stregSystem.GetTransactionList(user, 10))
            {
                Console.WriteLine(element.ToString());
            }

            Console.ReadKey();
        }

         /// <summary>
        /// Write out to the user that a request have too many arguments.
         /// </summary>
        public void DisplayTooManyArgumentsError()
        {
            Console.WriteLine("You can't use that numbers of arguments, try again.");
            Console.ReadKey();
        }

         /// <summary>
        /// Write out to the user that a requested command isn't valid.
         /// </summary>
         /// <param name="wrongCommand"></param>
        public void DisplayAdminCommandNotFoundMessage(string wrongCommand)
        {
            Console.WriteLine(wrongCommand + ", isn't a command, try again.");
            Console.ReadKey();
        }


        /// <summary>
        /// Write out the users last transaction
        /// </summary>
        /// <param name="transaction"></param>
        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
            Console.ReadKey();
        }

         /// <summary>
        /// Write out the users count last transaction
         /// </summary>
         /// <param name="count">the user to get parsed with the transaction</param>
         /// <param name="user">The numbers of last transactions.</param>
        public void DisplayUserBuysProduct(int count, User user)
        {
            foreach (Transaction element in stregSystem.GetTransactionList(user, count))
            {
                Console.WriteLine(element.ToString());
            }
            Console.ReadKey();
        }

         /// <summary>
         /// Closes the while loop in start.
         /// </summary>
        public void Close()
        {
            close = true;
        }

         /// <summary>
        /// Write out to the user that ´the user don't have enought money, to buy the product.
         /// </summary>
         /// <param name="user"></param>
         /// <param name="product"></param>
        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine("The " + product.Name + " cost " + product.Price/100 + "Dkk, but you just have " + user.Balance/100 + " Dkk.");
            Console.ReadKey();
        }

         /// <summary>
        /// Write out to the user a general error message.
         /// </summary>
         /// <param name="errorString"></param>
        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
            Console.ReadKey();
        }

         /// <summary>
         /// Start a loop and calls the parser.
         /// </summary>
         /// <param name="parser"></param>
        internal void Start(StregsystemCommandParser parser)
        {
            close = false;

            while (close == false)
            {
                Console.Clear();
                foreach (Product element in stregSystem.GetActiveProducts())
                {
                    Console.WriteLine(element.ToString());
                }
                try
                {
                    parser.CommandParser(Console.ReadLine());
                }
                catch (InsufficientCreditsException e)
                {
                    DisplayInsufficientCash(e.TheUser, e.TheProduct);
                }
                catch (NotAUserExeption e)
                {
                    DisplayUserNotFound(e.UserName);
                }
                catch (NotValidTextExeption e)
                {
                    DisplayGeneralError("The file product.csv has a not valid line. the text line: " + e.ToString());
                }
                catch (ProductNotActiveExeption e)
                {
                    DisplayProductNotFound(e.ProductId);
                }
                catch (FormatException)
                {
                    DisplayGeneralError("You can't use letters as numbers.");
                }
                catch(Exception e)
                {
                    DisplayGeneralError("Some unhandlet error: " + e.ToString());
                }
            }
        }
    }
}
