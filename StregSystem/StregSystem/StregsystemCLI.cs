using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Transactions;
using StregSystem.Products;

namespace StregSystem
{
    class StregsystemCLI : IStregsystemUI
    {

        public void DisplayUserNotFound(string userName)
        {
            Console.WriteLine(userName + " not found, try again.");
        }

        public void DisplayProductNotFound(uint id)
        {
            Console.WriteLine("ID: " + id + " not found, try again.");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.ToString());
        }

        public void DisplayTooManyArgumentsError()
        {
            Console.WriteLine("You can't use that numbers of arguments, try again.");
        }

        public void DisplayAdminCommandNotFoundMessage(string wrongCommand)
        {
            Console.WriteLine(wrongCommand + ", isn't a command, try again.");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }

        public void DisplayUserBuysProduct(int count, User user)
        {
            //Jeg forstår ikke hvad den skal gøre

            //Hvis den skal vise de 10 sidste købte produkter fra brugeren, skal jeg have adgang til streg system som indeholder listen over transactioner, og hvordan får jeg så adgang til den?
        }

        public void Close()
        {
            //close
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine("The " + product.Name + " cost " + product.Price/100 + "Dkk, but you just have " + user.Balance/100 + " Dkk.");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }
    }
}
