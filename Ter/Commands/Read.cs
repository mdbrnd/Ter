using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ter.UtilsNS;

namespace Ter.Commands
{
    internal class Read : ICommand
    {
        public string Name => "rd";

        public string Docs => "Usage: read <filename>";

        public void Execute(string[] args)
        {
            if (args != Array.Empty<string>()) {
                string filename = string.Join(" ", args);

                bool isInSubdir = false;
                // Check if file exists in subdirectory and then in path
                foreach (var file in Utils.getFilesInDir(Utils.currentDir)) {
                    if (file.Name == filename) {
                        isInSubdir = true;
                        // Read and print file
                        string[] lines = File.ReadAllLines(Utils.currentDir + '\\' + filename);
                        Utils.Write(bgColor: ConsoleColor.Yellow, ConsoleColor.Black, "Reading " + filename, ":", Environment.NewLine);
                        foreach (string line in lines) {
                            Console.WriteLine(line);
                        }
                    }
                }

                if (!isInSubdir) {
                    if (File.Exists(filename)) {
                        // Read and print file
                        string[] lines = File.ReadAllLines(filename);
                        Utils.Write(bgColor: ConsoleColor.Yellow, ConsoleColor.Black, filename, ": ", Environment.NewLine);
                        foreach (string line in lines) {
                            Console.WriteLine(line);
                        }
                    } else {
                        Console.WriteLine($"File \"{filename}\" does not exist");
                    }
                }
            } else {
                Console.WriteLine("Invalid usage" + Environment.NewLine + Docs);
            }

            Console.WriteLine();
        }
    }
}
