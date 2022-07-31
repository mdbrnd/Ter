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

        public string Docs => "List all files in the current directory";

        public string Usage => "Usage: ls";

        public void Execute(string[] args)
        {
            bool hasAtt = false;
            foreach (var file in Utils.GetFilesInDir(Utils.currentDir)) {
                hasAtt = false;
                foreach (KeyValuePair<FileAttributes, ConsoleColor> item in Utils.colorDict) {
                    if (file.Attributes.HasFlag(item.Key)) {
                        Utils.Write(bgColor: ConsoleColor.Black, item.Value, file.Name, Environment.NewLine);
                        hasAtt = true;
                    }
                }
                if (!hasAtt) {
                    Console.WriteLine(file.Name);
                }
            }
            Console.WriteLine();
        }
    }
}
