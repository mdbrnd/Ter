using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ter.UtilsNS;

namespace Ter.Commands.Files
{
    internal class CreateFile : ICommand
    {
        public string Name => "create";

        public string Docs => "Usage: create <filename>";

        public string Usage => throw new NotImplementedException();

        public void Execute(string[] args)
        {
            if (args != Array.Empty<string>()) {
                string filename = string.Join(" ", args);
                if (filename.Contains(':') || filename.Contains('\\')) {
                    Console.WriteLine("Invalid filename");
                } else {
                    if (Utils.FileExistsInDir(filename, Utils.currentDir)) {
                        Console.WriteLine(Environment.NewLine + $"File {filename} already exists. Do you want to overwrite it? (y/n)");
                        string? input = Console.ReadLine();
                        if (input == "y") {
                            var newFile = File.Create(Utils.currentDir.EndsWith('\\') ? Utils.currentDir + filename : Utils.currentDir + '\\' + filename);
                            newFile.Close();
                            Console.WriteLine();
                            Console.WriteLine($"Overwrote file {Utils.currentDir}\\{filename}");
                        }
                    } else {
                        try {
                            var newFile = File.Create(Utils.currentDir.EndsWith('\\') ? Utils.currentDir + filename : Utils.currentDir + '\\' + filename);
                            newFile.Close();
                            Console.WriteLine($"Created file {Utils.currentDir}\\{filename}");
                        }
                        catch (DirectoryNotFoundException) {
                            Console.WriteLine("Invalid filename");
                        }
                        catch (UnauthorizedAccessException) {
                            Utils.Write(bgColor: ConsoleColor.Black, ConsoleColor.Red, "ERR: Unauthorized access");
                        }
                    }
                }

            } else {
                Console.WriteLine("Invalid usage" + Environment.NewLine + Docs);
            }

            Console.WriteLine();
        }
    }
}
