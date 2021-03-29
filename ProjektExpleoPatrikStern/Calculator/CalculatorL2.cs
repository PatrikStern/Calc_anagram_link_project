using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjektPatrikStern.Calculator
{
    public class CalculatorL2
    {
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
    }
}
