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
        StregSystem stregSystem { get; set; }
        StregsystemCLI CLI { get; set; }

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
                char[] parser = {' ', ' '};
                string[] commandInfo = command.Split(parser);
                
                stregSystem.BuyProduct(stregSystem.GetUser(commandInfo[0]),stregSystem.GetProduct(Convert.ToUInt32(commandInfo[1])));
                
            }
            else if (MultiProduct.IsMatch(command))
            {
                char[] parser = { ' ', ' ', ' '};
                string[] commandInfo = command.Split(parser);
                int count = Convert.ToInt32(commandInfo[2]);
                for (int i = 0; i < count; i++)
                {
                    stregSystem.BuyProduct(stregSystem.GetUser(commandInfo[0]),stregSystem.GetProduct(Convert.ToUInt32(commandInfo[1])));
                }
                

            }
            else
            {
#warning        throw new NotACommandExeption(command); //smid en fejl
            }

        }

        public StregsystemCommandParser(StregsystemCLI CLI, StregSystem stregSystem)
        {
            this.CLI = CLI;
            this.stregSystem = stregSystem;
        }
    }
}
