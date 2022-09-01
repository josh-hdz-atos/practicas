using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PerformanceReview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz();
            RemoveLowerCase("RegExr was created by #gskinner.com, and is proudly hosted by Media Temple.\r\n\r\nedit the Expression & Text to see matches. Roll over matches or the expression for details. PCRE & JavaScript flavors of RegEx are supported. Validate your expression with Tests mode.\r\n\r\nThe side bar includes a Cheatsheet, full Reference, and Help. You can also Save & Share with the Community, and view patterns you create or favorite in My Patterns.\r\n\r\nExplore results with the Tools below. Replace & List output custom results. Details lists capture groups. Explain describes your expression in plain English.\r\n");
            NumberRepeated(new int[] { 0, 1, 3, 0, 2, 4, 5, 6, 9, 2, 7, 6, 9, 10, 20, 13, 14, 25, 30 });
        }

        static void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.Write($"{i}: ");
                if (i % 3 == 0) Console.Write("Fizz");
                if (i % 5 == 0) Console.Write("Buzz");
                Console.WriteLine("");
            }
        }

        static void RemoveLowerCase(string str)
        {
            string result = Regex.Replace(
                str,
                @"^[a-z]|[\W|_][a-z]",
                (Match match) =>
                {
                    if (match.Value[0] >= 97 & match.Value[0] <= 122)
                        return "";
                    else
                        return match.Value[0].ToString();
                }
            );

            Console.WriteLine(result);
        }

        static void NumberRepeated(int[] array)
        {
            var count = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
                if (count.ContainsKey((array[i])))
                    ++count[array[i]];
                else
                    count.Add(array[i], 1);

            foreach ((int key, int value) in count)
                Console.WriteLine($"the number {key} repeats {value}");
        }


    }
}
