using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ter.Commands
{
    internal class List : ICommand
    {
        public string Name => "ls";

        public string Docs => "Usage: ls";

        public void Execute(string?[] args)
        {
            throw new NotImplementedException();
        }
    }
}
