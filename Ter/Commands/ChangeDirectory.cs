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

        public void Execute(string[] args)
        {
            if (args != Array.Empty<string>()) {
                string dir = string.Join(" ", args);

                bool isSubdirectory = false;

                // First check if dir exists inside of current dir then check if exists on whole pc
                foreach (var file in Utils.GetFilesInDir(Utils.currentDir)) {
                    if (file.Attributes.HasFlag(FileAttributes.Directory)) {
                        if (file.Name == dir) {
                            isSubdirectory = true;
                            if (Utils.currentDir.EndsWith('\\')) {
                                Utils.currentDir += dir;
                            } else {
                                Utils.currentDir += "\\" + dir;
                            }
                        }
                    }
                }
                if (!isSubdirectory) {
                    if (Directory.Exists(dir)) {
                        Utils.currentDir = dir;
                    } else {
                        Console.WriteLine("No such directory: " + dir);
                        Console.WriteLine();
                    }
                }
                
            } else {
                Console.WriteLine("Invalid usage" + Environment.NewLine + Docs + Environment.NewLine);
            }
        }
    }
}
