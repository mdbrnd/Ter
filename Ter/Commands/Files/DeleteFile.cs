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

        public string Docs => "Deletes a file";

        public string Usage => "Usage: del <filename>";

        public void Execute(string[] args)
        {
            
        }
    }
}
