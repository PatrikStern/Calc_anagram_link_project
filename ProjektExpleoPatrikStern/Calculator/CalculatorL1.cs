using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjektPatrikStern.Calculator
{
    public class CalculatorL1
    {
        public static bool Loop = true;
        public static void CalculatorOptions()
        {
            while (Loop)
            {
                Console.Clear();
                Console.WriteLine("CALCULATOR\nUse 1-3 to navigate selections or press Q to stop the program.\n" +
                    "Press 1: Use calculator Level 1.\n" +
                    "Press 2: Use calculator Level 2.\n" +
                    "Press 3: Use calculator Level 3.\n" +
                    "Press B: To go back to meny.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        CalculatorLevel1();
                        break;
                    case ConsoleKey.D2:
                        CalculatorL2.CalculatorLevel2();
                        break;
                    case ConsoleKey.D3:
                        CalculatorL3.CalculatorLevel3();
                        break;
                    case ConsoleKey.B: StartMeny.startMeny();
                        Loop = false;
                        break;
                    default: Console.WriteLine("Use 1-3 to make your selection, or press B to go back to meny.");
                        break;
                }

       }    }

        public static void CalculatorLevel1()
        {
            try
            {
                Console.Clear();
                object result;
                Console.WriteLine("This calculator handles one operator and two numeric parameters.\n" +
                    "Which operator do you want to use for your calculation?: + - * / (Select key and press [ENTER])");
                string Operator = Console.ReadLine();
                Console.WriteLine($"Number 1 to calculate:");
                var numberOne = int.Parse(Console.ReadLine());
                Console.WriteLine($"Number 2 to calculate:");
                var numberTwo = int.Parse(Console.ReadLine());

                if (Operator == "+")
                {
                    result = numberOne + numberTwo;
                }
                else if (Operator == "-")
                {
                    result = numberOne - numberTwo;
                }
                else if (Operator == "*")
                {
                    result = numberOne * numberTwo;
                }
                else if (Operator == "/")
                {
                    result = numberOne / numberTwo;
                }
                else
                {
                    result = "Please only use addition, substraction, multipication or division in calculator";
                }
                Console.WriteLine(result);
                Console.WriteLine("To try again press A or press any key to go back to meny.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.A)
                {
                    CalculatorLevel1();
                }
                else
                {
                    StartMeny.startMeny();
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Ops, something went wrong.\n" +
                    "Please only use numbers and the choosble operators for calculation\n" +
                    "Press [ENTER] to try again or any key to go back to meny.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.Enter)
                {
                    CalculatorLevel1();
                }
                else
                {
                    StartMeny.startMeny();
                }
            }
            
        }
    }
}
