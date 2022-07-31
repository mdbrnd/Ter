using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ter.UtilsNS;

namespace Ter.Commands
{
    internal class ChangeDirectoryBack : ICommand
    {
        public string Name => "cd..";

        public string Docs => "Sets the current directory to the parent directory";

        public string Usage => "Usage: cd..";

        public void Execute(string[] args)
        {
            DirectoryInfo? parent = Directory.GetParent(Utils.currentDir);
            if (parent != null) {
                Utils.currentDir = parent.FullName;
            }
        }
    }
}
