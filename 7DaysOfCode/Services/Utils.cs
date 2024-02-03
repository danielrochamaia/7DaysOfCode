using _7DaysOfCode.Models;
using System.Text;

namespace _7DaysOfCode.Services
{
    public static class Utils
    {
        public static Settings GetSettings()
        {
            return new Settings().GetSettings();
        }

        public static int RandomStartLevel() => new Random().Next(1,7);

        public static void ShowOptions(Dictionary<string, string> dict)
        {
            foreach (var i in dict)
            {
                Console.WriteLine($"{i.Key} - {i.Value}");
            }
        }

        public static void PrintWaiting()
        {
            Thread.Sleep(350);
            Console.Write(".");
            Thread.Sleep(350);
            Console.Write(".");
            Thread.Sleep(350);
            Console.Write(".\n");
        }

        public static void PrintHeader(string header)
        {
            PrintWaiting();

            var len = (64 - header.Length) / 2;


            var hyphens = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                hyphens.Append('-');
            }

            if (header != "")
            {
                Console.WriteLine($"{hyphens} {header} {hyphens}");
            }
            else
            {
                Console.WriteLine($"------------------------------------------------------------------");
            }
        }
    }
}
