using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektExpleoPatrikStern.Anagram
{
    public class Anagram
    {

        public static void Dialog()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Put in two words and press [ENTER] to check if they are anagrams.\nYou can use both single and multiple word suggestions:");
                Console.Write("Word 1:\t");
                string wordOne = Console.ReadLine();
                Console.Write("Word 2:");
                string wordTwo = Console.ReadLine();

                Console.WriteLine($"{IsAnagram(wordOne, wordTwo)}\n");
                Console.WriteLine("To go again press A or press any key to go back to meny.");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.A)
                {
                    Dialog();
                }

            }
            catch
            {
                Console.WriteLine("Something went wrong. Only use letters for your anagram words.\n Press [ENTER] to continue. Any other key to navigate back to meny");
                
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.Enter)
                {
                    Dialog();
                }
                else
                {
                    StartMeny.startMeny();
                }

            }
        }  
            


        public static bool IsAnagram(string wordOne, string wordTwo)
        {
            try
            {
                int counter = 0;

                char[] wordOneEachLetter = (char[])wordOne.ToUpper().Where(L => !Char.IsWhiteSpace(L)).ToArray();
                char[] wordTwoEachLetter = (char[])wordTwo.ToUpper().Where(L => !Char.IsWhiteSpace(L)).ToArray();

                if (wordOneEachLetter.Length == wordTwoEachLetter.Length)
                {
                    Array.Sort(wordOneEachLetter);
                    Array.Sort(wordTwoEachLetter);

                    for (int i = 0; i < wordOneEachLetter.Length; i++)
                    {
                        if (wordOneEachLetter[i] == wordTwoEachLetter[i])
                        {
                            counter++;
                        }
                    }

                    if (counter == wordOneEachLetter.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
                Console.WriteLine("Something went wrong. Only use letters for your anagram words.\n Press [ENTER] to continue. Any other key to navigate back to meny");

                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                ConsoleKey key = consoleKey.Key;
                if (key == ConsoleKey.Enter)
                {
                    Dialog();
                }
                else
                {
                    StartMeny.startMeny();
                }
            } 
        }
    }
}
