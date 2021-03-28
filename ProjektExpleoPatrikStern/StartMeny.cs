using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektExpleoPatrikStern
{
    class StartMeny
    {
        public static async Task startMeny()
        {
            bool Loop = true;
            while (Loop)
            {
                Console.Clear();
                Console.WriteLine("Use 1-3 to navigate selections or press Q to stop the program.\n" +
                    "Press 1: To check if word is anagram to another.\n" +
                    "Press 2: To search a webpage for all of its published anchor links on page.\n" +
                    "Press 3: To go to calculator.\n" +
                    "Press Q: To stop the program.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        Anagram.Anagram.Dialog();
                        break;
                    case ConsoleKey.D2:
                        await FindAllLinks.Links.Dialog();
                        break;
                    case ConsoleKey.D3:
                        Calculator.Calculator.CalculatorOptions();
                        break;
                    case ConsoleKey.Q:
                        Loop = false;
                        break;

                    default:
                        Console.WriteLine("Use 1-3 to navigate selections or press Q to stop the program");
                        break;

                }
            }
        }
    }
}
