using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ter.UtilsNS;

namespace Ter.Commands
{
    internal class ChangeDirectory : ICommand
    {
        public string Name => "cd";

        public string Docs => "Usage: cd <directory>";

        public void Execute(string?[] args)
        {
            string? dir = args[0];
            if (!string.IsNullOrEmpty(dir)) {
                if (dir == "..") {
                    DirectoryInfo? parent = Directory.GetParent(Utils.currentDir);
                    if (parent != null) {
                        Utils.currentDir = parent.FullName;
                    }
                } else {
                    if (Directory.Exists(dir)) {
                        Utils.currentDir = dir;
                    } else {
                        Console.WriteLine("Invalid directory " + dir);
                    }
                }
            }
        }
    }
}
