using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ter.UtilsNS;

namespace Ter.Commands.Files
{
    internal class ReadFile : ICommand
    {
        public string Name => "rd";

        public string Docs => "Reads a file and prints its contents";

        public string Usage => "Usage: read <filename>";

        public void Execute(string[] args)
        {
            if (args != Array.Empty<string>()) {
                string filename = string.Join(" ", args);
                bool existsInSubdir = Utils.FileExistsInDir(filename, Utils.currentDir);

                if (existsInSubdir) {
                    // Read and print file
                    try {
                        string[] lines = Utils.currentDir.EndsWith('\\') ? File.ReadAllLines(Utils.currentDir + filename) : File.ReadAllLines(Utils.currentDir + '\\' + filename);
                        Utils.Write(bgColor: ConsoleColor.Yellow, ConsoleColor.Black, "Reading " + filename, ":");
                        Console.WriteLine();
                        foreach (string line in lines) {
                            Console.WriteLine(line);
                        }
                    }
                    catch (UnauthorizedAccessException) {
                        Utils.Write(bgColor: ConsoleColor.Black, ConsoleColor.Red, "ERR: Unauthorized access");
                        Console.WriteLine();
                    }
                } else {
                    if (File.Exists(filename)) {
                        // Read and print file
                        try {
                            string[] lines = File.ReadAllLines(filename);
                            Utils.Write(bgColor: ConsoleColor.Yellow, ConsoleColor.Black, filename, ":");
                            Console.WriteLine();
                            foreach (string line in lines) {
                                Console.WriteLine(line);
                            }
                        }
                        catch (UnauthorizedAccessException) {
                            Utils.Write(bgColor: ConsoleColor.Black, ConsoleColor.Red, "ERR: Unauthorized access");
                            Console.WriteLine();
                        }
                    } else {
                        Console.WriteLine($"File \"{filename}\" does not exist");
                    }
                }
            } else {
                Console.WriteLine(Usage + Environment.NewLine + Docs);
            }

            Console.WriteLine();
        }
    }
}
