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
        public static string machineName = Environment.MachineName;

        public static Dictionary<FileAttributes, ConsoleColor> colorDict = new Dictionary<FileAttributes, ConsoleColor>() {
            { FileAttributes.Directory, ConsoleColor.Green },
            { FileAttributes.Hidden, ConsoleColor.Yellow },
            { FileAttributes.Compressed, ConsoleColor.Magenta }
        };

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

        /// <summary>
        /// Gets a ICommand by a line input
        /// </summary>
        /// <param name="line"></param>
        /// <returns>An ICommand that is null if no command was found</returns>
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


        /// <summary>
        /// Gets the args from a line input
        /// </summary>
        /// <param name="line"></param>
        /// <returns>The args from a line expression. Array.Empty<> if args are empty</returns>
        public static string[] GetArgs(string line)
        {
            return line.Trim().Split(" ").Skip(1).ToArray();
        }

        public static FileSystemInfo[] GetFilesInDir(string pathToDir)
        {
            DirectoryInfo dir = new DirectoryInfo(pathToDir);
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            return files;
        }

        /// <summary>
        /// Returns whether a file exists in a given directory. A FileAttribute can be optionally passed to for example check whether a folder with a given name exists.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="dir"></param>
        /// <param name="attribute"></param>
        /// <returns>Whether a file exists in that directory or not</returns>
        public static bool FileExistsInDir(string filename, string dir, FileAttributes? attribute = null)
        {
            if (attribute == null) {
                foreach (var file in GetFilesInDir(dir)) {
                    if (file.Name == filename) {
                        return true;
                    }
                }
                return false;
            } else {
                foreach (var file in GetFilesInDir(dir)) {
                    if (file.Name == filename && file.Attributes.HasFlag(attribute)) {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
