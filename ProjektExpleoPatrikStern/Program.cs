using System;
using System.Threading.Tasks;


namespace ProjektExpleoPatrikStern
{
    class Program
    {
        
        static async Task Main(string[] args) /*Main changed to async Task to be able to work async with Links method*/
        {
            try 
            {
                await StartMeny.startMeny();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Ops, something went wrong! Please press [ENTER] and try again");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.Enter)
                {
                    await StartMeny.startMeny();
                }
            }
        }
    }
}
