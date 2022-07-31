using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ter.Commands
{
    internal class Exit : ICommand
    {
        public string Name => "exit";

        public string Docs => "Usage: exit";

        public string Usage => throw new NotImplementedException();

        public void Execute(string[] args) {
            Environment.Exit(0);
        }
    }
}
