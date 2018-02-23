using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LINQExrcse
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = Directory.GetCurrentDirectory() + @"\..\..\..\tekst.txt";

            #region Number 1.

            StreamReader sr = new StreamReader(textFilePath);

            int counter = 0;
            string delim = " .'";
            string[] fields = null;
            string line = null;

            while (!sr.EndOfStream)
            {
                line = sr.ReadToEnd();
                line.Trim();
                fields = line.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                counter += fields.Length;
            }
            Console.WriteLine("The amount of words in the text file (with \"" + delim + "\" being the delimiters/splitters): {0} ", counter);
            Console.WriteLine("\nPress enter for exercise 2.");
            Console.ReadLine();

            #endregion Number 1.

            #region Number 2.

            Console.Clear();

            var fileLetters = new List<string>();
            foreach (var item in File.ReadAllText(textFilePath))
            {
                fileLetters.Add(Convert.ToString(item));
            }

            var uniqueLetters = new List<string>();
            foreach (var item in fileLetters)
            {
                if (item == " ")
                { }
                if (!uniqueLetters.Contains(Convert.ToString(item)))
                {
                    uniqueLetters.Add(Convert.ToString(item));
                    Console.Write(item);
                }
                else
                { }
            }
            Console.WriteLine();
            Console.WriteLine("\nThe list above shows all of the unique characters (upper and lower) in the \"tekst.txt\" file.\n\nPress enter for exercise 3");
            Console.ReadLine();

            #endregion Number 2.

            #region Number 3.

            Console.Clear();

            var letterFrequency = File.ReadAllText(textFilePath)
                    .Where(c => Char.IsLetter(c))
                    .GroupBy(c => c)
                    .ToDictionary(g => g.Key, g => g.Count());

            foreach (KeyValuePair<char, int> kvp in letterFrequency)
            {
                Console.WriteLine("Letter: {0}  Frequency {1}", kvp.Key, kvp.Value);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nThe above list displays the text file character frequencies (Both upper and lower case)\n\nPress enter for exercise 4");
            Console.ReadLine();

            #endregion Number 3.

            #region Number 4.

            var uniqueWords = new List<string>();

            foreach (var item in fields)
            {
                if (!uniqueWords.Contains(item.ToLower()))
                {
                    uniqueWords.Add(item);
                    Console.Write(item + " ");
                }
                else { }
            }
            Console.WriteLine("\n");
            Console.WriteLine("\nThe above text is all of the \"tekst.txt\" text, but with no word repeating twice.\n\nMOST OF THE QUESTION MARKS ARE ACTUALLY UPPER COMMAS\nRESULTS NOT PERFECT DUE TO THAT ^");

            #endregion Number 4.

            Console.ReadLine();
        }
    }
}
