using System;
using System.Collections.Generic;

namespace csharp_advanced_I
{
    class Program
    {
        public delegate bool Comparer(int x, int y);

        static void Main(string[] args)
        {
            var l = new List<int>{1,4,23,7,8,0,12,3,24,65};
            PrintList(l, (iteam) => { return iteam % 2 == 0; });
            PrintList(l, (iteam) => { return iteam % 2 == 1; });

            bubbleSrt(l, (x, b) => { return x > b; });
            PrintList(l, (a) => { return true; });
            
            bubbleSrt(l, (x, b) => { return x < b; });
            PrintList(l, (a) => { return true; });

            Console.WriteLine($"{30} is " + (30 % 3 == 0 ? "multiple of 3" : "not multiple of 3"));
            
            Action<string> printer = delegate(string text) { Console.WriteLine(text); };

            printer("hola mundo");

            Func<List<int>, int> staatistics = Max;
            Console.WriteLine($"Max: {staatistics(l)}");

            staatistics = Min;
            Console.WriteLine($"Min: {staatistics(l)}");

            staatistics = Avg;
            Console.WriteLine($"Avg: {staatistics(l)}");

            Func<List<int>, double> stat = Rms;
            Console.WriteLine($"Rms: {stat(l)}");

            Console.ReadLine();
        }

        public static void PrintList(List<int> lst, Predicate<int> shouldPrint)
        {
            foreach(int item in lst)
                Console.Write(shouldPrint(item) ? $"{item} " : "");
            
            Console.WriteLine('\n');
        }

        public static void bubbleSrt(List<int> lst, Comparer compare)
        {
            int tmp;
            for (int i = 0; i < lst.Count - 1; i++)
                for (int j = 0; j < lst.Count - i - 1; j++)
                    if (compare(lst[j], lst[j + 1]))
                    {
                        tmp = lst[j];
                        // swap tmp and lst[i] int tmp = lst[j];
                        lst[j] = lst[j + 1];
                        lst[j + 1] = tmp;
                    }
        }

        public static int Max(List<int> lst) {
            int max = Int32.MinValue;

            foreach (int iteam in lst)
                max = iteam > max ? iteam : max;

            return max;
        }

        public static int Min(List<int> lst) {
            int min = Int32.MaxValue;

            foreach (int iteam in lst)
                min = iteam < min ? iteam : min;

            return min;
        }

        public static int Avg(List<int> lst) {
            int sum = 0;

            foreach (int iteam in lst)
                sum += iteam;

            return sum / lst.Capacity;
        }

        public static double Rms(List<int> lst)
        {
            double sum = 0;

            foreach(int iteam in lst)
                sum += Math.Pow(iteam, 2);

            sum /= lst.Capacity;

            return Math.Sqrt(sum);
        }

    }
}
