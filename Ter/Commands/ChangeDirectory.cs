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
                Console.WriteLine("Args: " + args[0]);

                string dir = args[0];
                if (dir == "..") {
                    DirectoryInfo? parent = Directory.GetParent(Utils.currentDir);
                    if (parent != null) {
                        Utils.currentDir = parent.FullName;
                    }
                } else {
                    bool hasFoundSubdir = false;

                    // First check if dir exists inside of current dir then check if exists on whole pc
                    foreach (var file in Utils.getFilesInDir(Utils.currentDir)) {
                        if (file.Attributes.HasFlag(FileAttributes.Directory)) {
                            if (file.Name == dir) {
                                hasFoundSubdir = true;
                                Utils.currentDir += "\\" + dir;
                            }
                        }
                    }
                    if (!hasFoundSubdir) {
                        if (Directory.Exists(dir)) {
                            Utils.currentDir = dir;
                        } else {
                            Console.WriteLine("Invalid directory " + dir);
                        }
                    }
                }
            } else {
                Console.WriteLine("Invalid usage" + Environment.NewLine + Docs + Environment.NewLine);
            }
        }
    }
}
