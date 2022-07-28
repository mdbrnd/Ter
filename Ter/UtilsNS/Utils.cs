using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Ter.Commands;

namespace Ter.UtilsNS
{
    internal static class Utils
    {
        // Get a list of classes that implement ICommand
        public static readonly Dictionary<string, ICommand> _Commands =
                    Assembly.GetExecutingAssembly().GetTypes()
                        .Where(t => typeof(ICommand).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                        .Select(t => Activator.CreateInstance(t))
                        .Cast<ICommand>()
                        .ToDictionary(command => command.Name, StringComparer.InvariantCulture);

        public static string currentDir = Directory.GetCurrentDirectory();

        public static string user = Environment.UserName;

        public static string[] typingHistory = Array.Empty<string>();

        /// <summary>
        /// Writes to console with a background color and switchable foreground colors. Example usage: Write(bgColor: ConsoleColor.Blue, ConsoleColor.Red, "RED ", ConsoleColor.Green, "GREEN ", null, "RESET/WHITE")
        /// </summary>
        /// <param name="bgColor"></param>
        /// <param name="objects"></param>
        public static void Write(ConsoleColor bgColor = ConsoleColor.Black, params object?[] objects)
        {
            ConsoleColor fgOriginal = Console.ForegroundColor;

            Console.BackgroundColor = bgColor;
            foreach (var o in objects)
                if (o == null)
                    Console.ForegroundColor = fgOriginal;
                else if (o is ConsoleColor)
                    Console.ForegroundColor = (ConsoleColor)o;
                else
                    Console.Write(o.ToString());
            Console.ResetColor();
        }

        public static ICommand? GetCommand(string line)
        {
            string command = line.Trim().Split(" ").First();
            foreach (KeyValuePair<string, ICommand> item in _Commands)
            {
                if (item.Key == command)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public static string?[] GetArgs(string line)
        {
            return line.Trim().Split(" ").Skip(1).ToArray();
        }

        // Why the <>, why isnt passing a type of array not enough: public static bool IsNullOrEmpty(T[] array)
        public static bool IsNullOrEmpty<T>(T[] array)
        {
            if (array == null || array.Length == 0)
                return true;
            else
                return array.All(item => item == null);
        }
    }
}
