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
            StregSystem stregsystem = new StregSystem();
            StregsystemCLI cli = new StregsystemCLI(stregsystem);
            StregsystemCommandParser parser = new StregsystemCommandParser(cli, stregsystem);
            cli.Start(parser);
            
            
            
        }
    }
}
