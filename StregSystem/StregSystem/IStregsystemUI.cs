using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StregSystem.Transactions;
using StregSystem.Products;

namespace StregSystem
{
    interface IStregsystemUI //Jeg kan ikke se hvad jeg skal bruge interfacet her til, og desuden skaber det problemmer.
    {
        void DisplayUserNotFound(string userName);
        void DisplayProductNotFound(uint id);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError();
        void DisplayAdminCommandNotFoundMessage(string wrongCommand);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count, User user);
        void Close();
        void DisplayInsufficientCash(User user, Product product);
        void DisplayGeneralError(string errorString);
    }
}
