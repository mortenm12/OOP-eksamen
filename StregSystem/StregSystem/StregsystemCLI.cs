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
         public StregSystem stregSystem;

         public bool close { get; set; }

         public StregsystemCLI(StregSystem stregsystem)
         {
             stregSystem = stregsystem;
         }

        public void DisplayUserNotFound(string userName)
        {
            Console.WriteLine(userName + " not found, try again.");
            Console.ReadKey();
        }

        public void DisplayProductNotFound(uint id)
        {
            Console.WriteLine("ID: " + id + " not found, try again.");
            Console.ReadKey();
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.ToString());

            foreach (Transaction element in stregSystem.GetTransactionList(user, 10))
            {
                Console.WriteLine(element.ToString());
            }

            Console.ReadKey();
        }

        public void DisplayTooManyArgumentsError()
        {
            Console.WriteLine("You can't use that numbers of arguments, try again.");
            Console.ReadKey();
        }

        public void DisplayAdminCommandNotFoundMessage(string wrongCommand)
        {
            Console.WriteLine(wrongCommand + ", isn't a command, try again.");
            Console.ReadKey();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
            Console.ReadKey();

        }

        public void DisplayUserBuysProduct(int count, User user)
        {
            foreach (Transaction element in stregSystem.GetTransactionList(user, count))
            {
                Console.WriteLine(element.ToString());
            }
            Console.ReadKey();
        }

        public void Close()
        {
            close = true;
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine("The " + product.Name + " cost " + product.Price/100 + "Dkk, but you just have " + user.Balance/100 + " Dkk.");
            Console.ReadKey();
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
            Console.ReadKey();
        }

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
                    DisplayGeneralError("The file product.csv has a not valid line.");
                }
                catch (ProductNotActiveExeption e)
                {
                    DisplayProductNotFound(e.ProductId);
                }
            }
        }
    }
}
