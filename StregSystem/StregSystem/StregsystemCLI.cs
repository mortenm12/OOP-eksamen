﻿using System;
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
         public StregSystem stregSystemm;

         public bool close { get; set; }

         public StregsystemCLI(StregSystem stregsystem)
         {
             stregSystemm = stregsystem;
         }
        public StregSystem stregSystem { get; set; }

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
            Console.WriteLine(stregSystemm.GetTransactionList(user, count).ToString());
        }

        public void Close()
        {
            close = true;
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine("The " + product.Name + " cost " + product.Price/100 + "Dkk, but you just have " + user.Balance/100 + " Dkk.");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }

        internal void Start(StregsystemCommandParser parser)
        {
            close = false;

            stregSystemm.FillProductList();


            while (close == false)
            {
                Console.Clear();
                Console.WriteLine(stregSystem.GetActiveProducts().ToString());
                parser.CommandParser(Console.ReadLine());
            }
        }
    }
}
