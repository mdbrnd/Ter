using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ter.UtilsNS;

namespace Ter.Commands
{
    internal class List : ICommand
    {
        public string Name => "ls";

        public string Docs => "Usage: ls";

        public void Execute(string[] args)
        {
            foreach (var file in Utils.getFilesInDir(Utils.currentDir)) {
                if (file.Attributes.HasFlag(FileAttributes.Directory)) {
                    Utils.Write(bgColor: ConsoleColor.Black, ConsoleColor.Red, file.Name, Environment.NewLine);
                } else {
                    Console.WriteLine(file.Name);
                }
            }
            Console.WriteLine();
        }
    }
}
