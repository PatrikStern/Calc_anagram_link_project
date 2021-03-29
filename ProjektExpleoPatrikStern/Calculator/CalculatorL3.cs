using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjektPatrikStern.Calculator
{
    class CalculatorL3
    {
        public static void CalculatorLevel3()
        {
            try
            {
                Console.Clear();
                double calculation = 0;
                int controller = 0;
                int firstRun = 0;

                Console.WriteLine("This calculator handles multiple number calculations with different operators in some          combinations.\n" +
                        "Funtional operators = + - * /.\n" +
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
                            calculation = -double.Parse(numSerie[i]) * (double.Parse(numSerie[i + 1]));
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
                        //if (opSerie[i - 1] == '-')
                        //{
                        //    calculation = double.Parse(numSerie[i - 1]) * -double.Parse(numSerie[i]) / (double.Parse(numSerie[i + 1]));
                        //    firstRun++;
                        //    opSerie.RemoveAt(i);
                        //    opSerie.RemoveAt(i - 1);
                        //    numSerie.RemoveAt(i);
                        //    numSerie.RemoveAt(i);
                        //    numSerie.RemoveAt(i - 1);

                        //}
                        //else
                        //{
                            calculation = double.Parse(numSerie[i]) / (double.Parse(numSerie[i + 1]));
                            opSerie.RemoveAt(i);
                            numSerie.RemoveAt(i);
                            numSerie.RemoveAt(i);
                            firstRun++;
                        //}

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
