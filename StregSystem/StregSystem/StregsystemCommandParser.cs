using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StregSystem
{
    class StregsystemCommandParser : IStregsystem
    {
        public void CommandParser(string command)
        {
            Regex OneProduct = new Regex(@"[a-z0-9] [0-9]$");
            Regex MultiProduct = new Regex(@"[a-z0-9] [0-9] [0-9]$");
            if(command.StartsWith(":"))
            {
                //admin command
            }
            else if(OneProduct.IsMatch(command))
            {

            }
            else if (MultiProduct.IsMatch(command))
            {
                
            }
            else
            {
#warning        throw new NotACommandExeption(command); //smid en fejl
            }

        }
    }
}
