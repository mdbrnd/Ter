using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ter.Commands.Files
{
    internal class DeleteFile : ICommand
    {
        public string Name => "del";

        public string Docs => "Usage: del <filename>";

        public string Usage => throw new NotImplementedException();

        public void Execute(string[] args)
        {
            
        }
    }
}
