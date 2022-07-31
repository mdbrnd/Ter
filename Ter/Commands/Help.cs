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

        //public string Docs => "Gets the docs of any command. \nAvailable commands: \n";
        public string Docs
        {
            get {
                string docs = "Available commands: \n";
                foreach (var command in Utils._Commands) {
                    docs += command.Key + Environment.NewLine;
                }
                return docs; 
            }
        }

        public string Usage => "Usage: help <command_name>";

        public void Execute(string[] args)
        {
            if (args != Array.Empty<string>())
            {
                ICommand? cmd = Utils.GetCommand(args[0]);
                if (cmd != null)
                {
                    Console.WriteLine(cmd.Usage + Environment.NewLine + cmd.Docs);
                } else {
                    Console.WriteLine("Invalid command: " + args[0] + Environment.NewLine + Docs);
                }
            } else {
                Console.WriteLine(Usage + Environment.NewLine + Docs);
            }

            Console.WriteLine();

        }
    }
}
