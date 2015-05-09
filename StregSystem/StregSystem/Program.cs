using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ID.NextUserId = 0;
            StregSystem Streg = new StregSystem();
            User User1 = new User();
            User1.Balance = 100000;
            User1.Email="mortenm12@hotmail.com";
            User1.FirstName="Morten";
            User1.LastName = "Rasmussen";
            User1.UserName = "mortenm12";
            
            
            
        }
    }
}
