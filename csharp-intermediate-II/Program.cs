using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace csharp_intermediate_II
{
    class Program
    {
        static void Main(string[] args)
        {
          // ------------------------ Tuples ----------------------------
          List<(int, int)> lst1 = new List<(int, int)> {(1, 2)};
          var lst2 = new List<(
            string Name,
            string Kind,
            int Replicas,
            bool Run
          )> {
            (
              "skyworth",
              "STB",
              5,
              true
            )
          };


          Console.WriteLine($"{lst1[0].Item1}, {lst1[0].Item2}");
          Console.WriteLine($"{lst2[0].Name}, {lst2[0].Kind}, {lst2[0].Replicas}, {lst2[0].Run}");

          // ------------------------ Value and reference ----------------------------
          var cls = new List<Class>();
          var stc = new List<Struct>();
          Stopwatch sw = new Stopwatch();

          sw.Start();
          for (int i = 0; i < 1000000; ++i)
            cls.Add(new Class(i, "nombre", "pass"));
          sw.Stop();

          Console.WriteLine(sw.Elapsed);
          sw.Reset();

          sw.Start();
          for (int i = 0; i < 1000000; ++i)
            stc.Add(new Struct(i, "nombre", "pass"));
          sw.Stop();

          Console.WriteLine(sw.Elapsed);
          sw.Reset();
          // ------------------------ Data structures ----------------------------
          
          int[] a = new int[] { 1, 2, 3, 4, 5 };

          sw.Start();
          a = QueueReverse(a);
          sw.Stop();

          Console.WriteLine($"Queue reverse {sw.Elapsed}   {a[0]}");
          sw.Reset();
          a = new int[] { 1, 2, 3, 4, 5 };

          sw.Start();
          a = ListReverse(a);
          sw.Stop();

          Console.WriteLine($"List reverse {sw.Elapsed}   {a[0]}");
          sw.Reset();
          a = new int[] { 1, 2, 3, 4, 5 };

          sw.Start();
          a = DictReverse(a);
          sw.Stop();

          Console.WriteLine($"Dictionary reverse {sw.Elapsed}   {a[0]}");
          sw.Reset();

            // ------------------------ Stack ----------------------------
          Console.WriteLine(isPalindrome("aabbaa"));
          Console.WriteLine(isPalindrome("aabybaa"));
          Console.WriteLine(isPalindrome("ababaa"));

          var z = Console.ReadLine();
        }

        static bool isPalindrome(string word)
        {
          var stk = new Stack<int>();
          int mid = word.Length / 2;
          
          for (int i = 0; i < mid; i++)
            stk.Push(word[i]);

          if (word.Length % 2 != 0)
            ++mid;

          for (int i = mid; i < word.Length; i++)
            if (word[i] == stk.Peek())
              stk.Pop();
            else
              return false;

          return true;
        }

        static int[] QueueReverse(int[] array)
        {
          var container = new Queue<int>(array);

          for (int i = array.Length - 1; i >= 0 ; --i)
            array[i] = container.Dequeue(); 

          return array;
        }

        static int[] ListReverse(int[] array)
        {
          var container = new List<int>(array);

          for (int i = 0; i < array.Length ; ++i)
            array[i] = container[array.Length - 1 - i];

          return array;
        }

        static int[] DictReverse(int[] array)
        {
          var container = new Dictionary<int, int>(array.Length);

          for (int i = array.Length - 1; i >= 0 ; --i)
            container.Add(i, array[array.Length - 1 - i]);

          for (int i = array.Length - 1; i >= 0 ; --i)
            array[i] = container[i]; 

          return array;
        }
    }
}
