﻿using System;
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
        // TODO: multiple names, print file contents, color map for FileAttributes enum, don't split every space for cd because otherwise you cant access folder with spaces in them, add autosuggest with tab
        public static void Run()
        {
            string? input = "";

            while (input != "exit")
            {
                Utils.Write(bgColor: ConsoleColor.Black, ConsoleColor.DarkGray, Utils.currentDir, "> ");
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
    }
}
