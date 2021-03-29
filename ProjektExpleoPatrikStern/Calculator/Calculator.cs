using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektExpleoPatrikStern.Calculator
{
    class Calculator
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
                        CalculatorLevel2();
                        break;
                    case ConsoleKey.D3:
                        CalculatorLevel3();
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


        public static void CalculatorLevel2()
        {
            try
            {
                Console.Clear();
                double calculation = 0;
                int controller = 0;
                int firstRun = 0;
                Console.WriteLine("This calculator handles multiple number calculations with operators of the same 'family'.\n" +
                    "You can for example use addition and substaction togheter with eachother.\n" +
                    "Or use multiplication and division with eachother.\n" +
                    "Starting negative number not supported.\n" +
                    "Give calculation serie as full string: "); ;
                var input = Console.ReadLine();

                var numSerie = input.Split('+', '-', '*', '/');
                char[] opSerie = input.Where(c => !Char.IsNumber(c)).ToArray();

                foreach (var num in numSerie)
                {
                    if (firstRun == 0)
                    {
                        calculation = calculation + double.Parse(num.ToString());
                        firstRun++;
                        continue;
                    }

                    int run = 0;

                    for (int i = 0; i < opSerie.Length; i++)
                    {
                        if (opSerie[i + controller] == '+')
                        {
                            calculation = calculation + double.Parse(num);
                            run++;
                        }
                        else if (opSerie[i + controller] == '-')
                        {
                            calculation = calculation - double.Parse(num);
                            run++;
                        }
                        else if (opSerie[i + controller] == '*')
                        {
                            calculation = calculation * double.Parse(num);
                            run++;
                        }
                        else if (opSerie[i + controller] == '/')
                        {
                            calculation = calculation / double.Parse(num);
                            run++;
                        }
                        if (run > 0)
                        {
                            break;
                        }
                    }
                    controller++;
                }

                Console.WriteLine(calculation);
                Console.WriteLine("To try again press A or press any key to go back to meny.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.A)
                {
                    CalculatorLevel2();
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
                    CalculatorLevel2();
                }
                else
                {
                    StartMeny.startMeny();
                }
            }
        }

        public static void CalculatorLevel3()
        {
            try
            {
                Console.Clear();
                double calculation = 0;
                int controller = 0;
                int firstRun = 0;

                Console.WriteLine("This calculator handles multiple number calculations with different operators.\n" +
                        "Funtional operators = + - * /.\n" +
                        "Basic parenthises rules will be applied where possible but should not be given.\n" +
                        "Starting negative number not supported.\n" +
                        "Give calculation serie as full string: ");
                var input = Console.ReadLine();

                var numSerie = input.Split('+', '-', '*', '/').ToList();
                var opSerie = input.Where(c => !Char.IsNumber(c)).ToList();

                for (int i = 0; i < opSerie.Count; i++)
                {
                    if (opSerie[i] == '*')
                    {
                        if (opSerie[i - 1] == '-')
                        {
                            calculation =  -double.Parse(numSerie[i]) * (double.Parse(numSerie[i + 1]));
                            firstRun++;
                            opSerie.RemoveAt(i);
                            opSerie.RemoveAt(i - 1);
                            numSerie.RemoveAt(i);
                            numSerie.RemoveAt(i);
                        }
                        else
                        {
                            calculation = double.Parse(numSerie[i]) * (double.Parse(numSerie[i + 1]));
                            opSerie.RemoveAt(i);
                            numSerie.RemoveAt(i);
                            numSerie.RemoveAt(i);
                            firstRun++;
                        }

                    }
                    else if (opSerie[i] == '/')
                    {
                        if (opSerie[i - 1] == '-')
                        {
                            calculation = double.Parse(numSerie[i - 1]) * -double.Parse(numSerie[i]) / (double.Parse(numSerie[i + 1]));
                            firstRun++;
                            opSerie.RemoveAt(i);
                            opSerie.RemoveAt(i - 1);
                            numSerie.RemoveAt(i);
                            numSerie.RemoveAt(i);
                            numSerie.RemoveAt(i - 1);

                        }
                        else
                        {
                            calculation = double.Parse(numSerie[i]) / (double.Parse(numSerie[i + 1]));
                            opSerie.RemoveAt(i);
                            numSerie.RemoveAt(i);
                            numSerie.RemoveAt(i);
                            firstRun++;
                        }

                    }
                }

                foreach (var num in numSerie)
                {
                    if (firstRun == 0)
                    {
                        calculation = calculation + double.Parse(num.ToString());
                        firstRun++;
                        continue;
                    }
                    else if (numSerie.Count > 0 && opSerie.Count < 1)
                    {
                        calculation = calculation + double.Parse(num.ToString());
                        firstRun++;
                        break;
                    }

                    int run = 0;

                    for (int i = 0; i < opSerie.Count; i++)
                    {
                        if (opSerie[i + controller] == '+')
                        {
                            calculation = calculation + double.Parse(num);
                            run++;
                        }
                        else if (opSerie[i + controller] == '-')
                        {
                            calculation = calculation - double.Parse(num);
                            run++;
                        }
                        if (run > 0)
                        {
                            break;
                        }
                    }
                    controller++;
                }
                Console.WriteLine(calculation);
                Console.WriteLine("To try again press A or press any key to go back to meny.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.A)
                {
                    CalculatorLevel3();
                }
                else
                {
                    StartMeny.startMeny();
                }
            }
            
            catch
            {
                Console.Clear();
                Console.WriteLine("Ops, something went wrong. The given serie might have been too advanced.\n" +
                    "Please only use numbers and the choosble operators for calculation\n" +
                    "Press [ENTER] to try again or any key to go back to meny.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.Enter)
                {
                    CalculatorLevel3();
                }
                else
                {
                    StartMeny.startMeny();
                }
            }
        }       
    }
}
