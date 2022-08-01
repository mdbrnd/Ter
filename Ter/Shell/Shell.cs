using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ter.Commands;
using Ter.UtilsNS;

namespace Ter.Shell
{
    internal static class Shell
    {
        // TODO: multiple names for commands, add autosuggest with tab, advanced ls, delete file, figure out what to do with nerd font
        public static void Run()
        {
            string? input = "";

            while (true)
            {
                WriteCurrentDir();
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)) {
                    continue;
                }

                input.Trim();
                ICommand? command = Utils.GetCommand(input.ToLower());

                if (command != null) {
                    command.Execute(Utils.GetArgs(input));
                } else {
                    Console.WriteLine($"Command not found: {input.Split(" ").First()}" + Environment.NewLine);
                }
            }
        }

        public static void WriteCurrentDir()
        {
            Utils.Write(bgColor: ConsoleColor.Black, ConsoleColor.Green, Utils.semiCircleLeftFacing); // Semi circle
            Utils.Write(bgColor: ConsoleColor.Green, Utils.username + " "); // Username and machine name
            Utils.Write(bgColor: ConsoleColor.Black, ConsoleColor.Green, Utils.arrow); // Arrow
            Utils.Write(bgColor: ConsoleColor.Gray, ConsoleColor.Black, Utils.arrow, ConsoleColor.White, " " + Utils.currentDir + " "); // Current dir and arrow
            Utils.Write(bgColor: ConsoleColor.Black, ConsoleColor.Gray, Utils.arrow); // Arrow
            Utils.Write(bgColor: ConsoleColor.Blue, ConsoleColor.Black, Utils.arrow, ConsoleColor.White, " " + Utils.checkMark + " "); // Check mark
            Utils.Write(bgColor: ConsoleColor.Black, ConsoleColor.Blue, Utils.semiCircleRightFacing + " "); // Semi circle at the end
        }
    }
}
