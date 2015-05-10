using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using StregSystem.Transactions;

namespace StregSystem
{
    class StregsystemCommandParser : IStregsystem
    {
        StregSystem stregSystem { get; set; }
        IStregsystemUI CLI { get; set; }

        public void CommandParser(string command)
        {
            string[] space = command.Split(' '); //deler command efter mellemrum og senere tælles der mellemrum
    
            if(command.StartsWith(":"))
            {
                Regex activate = new Regex(@":activate [0-9]+$");
                Regex deactivate = new Regex(@":deactivate [0-9]+$");
                Regex crediton = new Regex(@":crediton [0-9]+$");
                Regex creditoff = new Regex(@":creditoff [0-9]+$");
                Regex addcredits = new Regex(@":addcredits [a-z0-9]+ [0-9]+$");
                char[] parser = {' '};
                if (command == ":q" || command == ":quit")
                {
                    CLI.Close();
                }
                else if (activate.IsMatch(command))
                {
                    string[] commandinfo = command.Split(parser);
                    stregSystem.GetProduct(Convert.ToUInt32(commandinfo[1])).Active = true;
                }
                else if (deactivate.IsMatch(command))
                {
                    string[] commandinfo = command.Split(parser);
                    stregSystem.GetProduct(Convert.ToUInt32(commandinfo[1])).Active = false;
                }
                else if (crediton.IsMatch(command))
                {
                    string[] commandinfo = command.Split(parser);
                    stregSystem.GetProduct(Convert.ToUInt32(commandinfo[1])).CanBeBoughtOnCredit = true;
                }
                else if (creditoff.IsMatch(command))
                {
                    string[] commandinfo = command.Split(parser);
                    stregSystem.GetProduct(Convert.ToUInt32(commandinfo[1])).CanBeBoughtOnCredit = false;
                }
                else if (addcredits.IsMatch(command))
                {
                    char[] creditparser = {' ',' ' };
                    string[] commandinfo = command.Split(creditparser);
                    stregSystem.GetUser(commandinfo[1]).Balance += Convert.ToInt32(commandinfo[2]);
                    
                }
                else
                {
                    CLI.DisplayAdminCommandNotFoundMessage(command);
                }

            }
            else if(space.Length==3)
            {
                char[] parser = { ' ', ' ' };
                string[] commandInfo = command.Split(parser);
                int count = Convert.ToInt32(commandInfo[2]);
                for (int i = 0; i < count; i++)
                {
                    stregSystem.BuyProduct(stregSystem.GetUser(commandInfo[0]), stregSystem.GetProduct(Convert.ToUInt32(commandInfo[1])));
                }
            }
            else if(space.Length==2)
            {
                char[] parser = {' '};
                string[] commandInfo = command.Split(parser);
                
                
                stregSystem.BuyProduct(stregSystem.GetUser(commandInfo[0]), stregSystem.GetProduct(Convert.ToUInt32(commandInfo[1])));
                
                
            }
            
            else
            {

                CLI.DisplayUserInfo(stregSystem.GetUser(command));
            }

        }

        public StregsystemCommandParser(StregsystemCLI CLI, StregSystem stregSystem)
        {
            this.CLI = CLI;
            this.stregSystem = stregSystem;
        }
    }
}
