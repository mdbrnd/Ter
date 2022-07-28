using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ter.UtilsNS;

namespace Ter.Commands
{
    internal class Help : ICommand
    {
        public string Name => "help";
        public string Docs => "Usage: help <command_name>";
        public void Execute(string[] args)
        {
            if (args != Array.Empty<string>())
            {
                ICommand? cmd = Utils.GetCommand(args[0]);
                if (cmd != null)
                {
                    Console.WriteLine(cmd.Docs);
                    Console.WriteLine();
                } else {
                    Console.WriteLine("Invalid command: " + args[0]);
                    Console.WriteLine();
                }
            } else {
                Console.WriteLine("Invalid usage of " + Name + Environment.NewLine + Docs);
                Console.WriteLine();
            }
        }
    }
}
