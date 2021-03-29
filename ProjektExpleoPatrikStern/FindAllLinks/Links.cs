using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace ProjektPatrikStern.FindAllLinks
{
    public class Links
    {
        public static async Task Dialog()
        {
            Console.Clear();
            Console.WriteLine("In this method you can search a specific webpage and get a list of its containing anchor links.\n" +
                "Write the page you want to search, For example: http://google.com and press [ENTER]. ");

            string input = Console.ReadLine();
            Uri url = new Uri(input);

            var _responseBack = await GetAllLinks(url);
            if (_responseBack.Count > 0)
            {
                foreach (var alinks in _responseBack)
                {
                    Console.WriteLine(alinks);
                }
                Console.WriteLine("To try again press A or press any key to go back to meny.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.A)
                {
                    await Dialog();
                }
            }
            else
            {
                Console.WriteLine("No links on page was found, either it might be a fault webadress or the page contains no links.");
                Console.WriteLine("To try again press A or press any key to go back to meny.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.A)
                {
                    await Dialog();
                }
            }
        }

        public static async Task<MatchCollection> GetAllLinks(Uri url)
        {
            MatchCollection collection = null;
            try
            {

                var methodRespons = new List<object>();
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                const string pattern = @"a href=""(?<link>.+?)""";
                Regex regularExpression = new Regex(pattern, RegexOptions.IgnoreCase);
                collection = regularExpression.Matches(content);

            }
            catch (Exception e)
            {
                Console.WriteLine("Something in the method went wrong, you might have typed a fault adress.\n" +
                    "Press A to try again or any key to navigate back to meny");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.A)
                {
                    await Dialog();
                }
                else
                {
                    await StartMeny.startMeny();
                }
            }
                return collection;
        }
    }
}
