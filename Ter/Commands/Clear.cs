using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ter.Commands 
{
    internal class Clear : ICommand
    {
        public string Name => "clear";

        public string Docs => "Clears the console";

        public string Usage => "Usage: clear";

        public void Execute(string[] args)
        {
            Console.Clear();
        }
    }
}
