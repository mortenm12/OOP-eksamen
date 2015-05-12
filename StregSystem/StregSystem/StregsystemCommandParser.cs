using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using StregSystem.Transactions;

namespace StregSystem
{
    class StregsystemCommandParser
    {
        /// <summary>
        /// THe stregsystem that is used.
        /// </summary>
        StregSystem stregSystem { get; set; }

        /// <summary>
        /// The User interface where all the info is gonna get showed.
        /// </summary>
        IStregsystemUI CLI { get; set; }

        /// <summary>
        /// The big black box where all the data is going in, and some random command is gonna get running :D
        /// </summary>
        /// <param name="command">That one line that makes all the magic.</param>
        public void CommandParser(string command)
        {
            
            string[] commandlist = command.Split(' ');
            if(command.StartsWith(":"))
            {

                Dictionary<string,Action<string[]>> AdminCommands = new Dictionary<string, Action<string[]>>();     //lært om dictionary på MSDN
                AdminCommands.Add(":activate", (commandinfo) => stregSystem.GetProduct(Convert.ToUInt32(commandinfo[1])).Active = true);
                AdminCommands.Add(":deactivate", (commandinfo) => stregSystem.GetProduct(Convert.ToUInt32(commandinfo[1])).Active = false);
                AdminCommands.Add(":crediton", (commandinfo) => stregSystem.GetProduct(Convert.ToUInt32(commandinfo[1])).CanBeBoughtOnCredit = true);
                AdminCommands.Add(":creditof", (commandinfo) => stregSystem.GetProduct(Convert.ToUInt32(commandinfo[1])).CanBeBoughtOnCredit = false);
                AdminCommands.Add(":addcredits", (commandinfo) => stregSystem.GetUser(commandinfo[1]).Balance += Convert.ToInt32(commandinfo[2]));
                AdminCommands.Add(":q", (commandinfo) => CLI.Close());
                AdminCommands.Add(":quit", (commandinfo) => CLI.Close());

                try
                {
                    AdminCommands[commandlist[0]](commandlist);
                }
                catch(ArgumentException)
                {
                    CLI.DisplayAdminCommandNotFoundMessage(command);
                }
                 

            }
            else if(commandlist.Length==3)
            {
                char[] parser = { ' ', ' ' };
                string[] commandInfo = command.Split(parser);
                int count = Convert.ToInt32(commandInfo[2]);
                for (int i = 0; i < count; i++)
                {
                    stregSystem.BuyProduct(stregSystem.GetUser(commandInfo[0]), stregSystem.GetProduct(Convert.ToUInt32(commandInfo[1])));
                }
                CLI.DisplayUserBuysProduct(count, stregSystem.GetUser(commandInfo[0]));
            }
            else if(commandlist.Length==2)
            {
                char[] parser = {' '};
                string[] commandInfo = command.Split(parser);
                
                
                stregSystem.BuyProduct(stregSystem.GetUser(commandInfo[0]), stregSystem.GetProduct(Convert.ToUInt32(commandInfo[1])));

                CLI.DisplayUserBuysProduct((BuyTransaction)stregSystem.ExecutedTransactions[stregSystem.ExecutedTransactions.Count-1]);
                
            }
            else if(commandlist.Length > 2)
            {
                CLI.DisplayTooManyArgumentsError();

            }
            
            else
            {

                CLI.DisplayUserInfo(stregSystem.GetUser(command));
            }

        }

        /// <summary>
        /// THe construtor that takes at streg system and a User interface.
        /// </summary>
        /// <param name="CLI"> The User Interface.</param>
        /// <param name="stregSystem">The Streg system.</param>
        public StregsystemCommandParser(StregsystemCLI CLI, StregSystem stregSystem)
        {
            this.CLI = CLI;
            this.stregSystem = stregSystem;
        }
    }
}
