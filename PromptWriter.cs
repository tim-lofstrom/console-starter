using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class PromptWriter
    {
        public static string Prompt { get; set; } = ">";
        public static string Name { get; set; } = "console";
        public static string Subcommand { get; set; } = string.Empty;

        internal static void WritePrompt()
        {
            string subcommand = Subcommand == string.Empty ? string.Empty : $"({Subcommand})";
            Console.Write($"{Name}{subcommand}{Prompt}");
        }
    }
}
