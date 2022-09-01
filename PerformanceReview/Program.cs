using System;
using System.Text.RegularExpressions;

namespace PerformanceReview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz();
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

        static void RemoveLowerCase(ref string str)
        {
            Regex expression = new Regex();

            Regex.Replace(
                str,
                "^[a-z]|[\n][a-z]|[ ][a-z]",
                (Match match) =>{
                    if (match.value[0] == ' ')
                        return ' ' + match.value[1].ToUpper();
                    else
                        return match.value[0].ToUpper();
                }
            ) 
        }
    }
}
