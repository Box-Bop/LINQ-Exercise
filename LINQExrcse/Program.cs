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
            string delim = " ,.";
            string[] fields = null;
            string line = null;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                line.Trim();
                fields = line.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                counter += fields.Length;
            }
            Console.WriteLine("The amount of words in the text file (with \" ,.\" being the delimiters/splitters): {0} ", counter);
            Console.WriteLine("Press enter for exercise 2.");
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
                if (!uniqueLetters.Contains(Convert.ToString(item.ToLower())))
                {
                    uniqueLetters.Add(Convert.ToString(item));
                }
                else
                { }
            }
            for (int i = 0; i < uniqueLetters.Count; i++)
            {
                Console.Write(uniqueLetters[i]);
            }

            Console.WriteLine(fileLetters);

            #endregion Number 2.

            #region Number 3.

            //var fileLetters = new List<string>();
            //foreach (var item in File.ReadAllText(textFilePath))
            //{
            //    fileLetters.Add(Convert.ToString(item));
            //}

            //var uniqueLetters = new List<string>();
            //foreach (var item in fileLetters)
            //{
            //    if (uniqueLetters.Contains(item))
            //    { }
            //    if (item == " ")
            //    { }
            //    else
            //    {
            //        uniqueLetters.Add(item);
            //    }
            //}

            #endregion Number 3.

            Console.ReadLine();
        }
    }
}
