using System;
using System.IO;

namespace csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var part1 = new GeneralConsepts();
                var part2 = new Offspring(10, "hola", 4.0);
                var part3 = new ExeptionHadleing();

                // IDE takes cwd as current folder + /bin/debug/net5.0. Had to jump back up  multiple times (../);
                part1.GreeCountries(
                    Directory.GetCurrentDirectory() + "../../../../Countries.txt",

                    Directory.GetCurrentDirectory() + "../../../../Countries " + DateTime.Today.ToString("yyyy-MMM-dd") + ".txt"
                );

                part2.GetPrivate1();
                part2.GetPrivate2();
                part2.GetData3();

                part3.Fail();
            }
            catch(FileNotFoundException err)
            {
                Console.WriteLine(err.Message);
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }
    }
    internal class GeneralConsepts
    {
        public void GreeCountries(String InputFile, String OutputFile)
        {
            using (StreamReader reader = new StreamReader(InputFile))
            {
                using (StreamWriter writer = new StreamWriter(@OutputFile))
                {
                    string country;

                    while ((country = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(String.Format("Saludos hasta {0}", country));
                    }
                }
            }
        }
    }
    internal abstract class Father
    {
        private protected int data1;
        private protected string data2;

        private protected abstract int Process1();
        private protected abstract string Process2();
    }
    internal sealed class Offspring : Father
    {
        private double data3;

        public Offspring(int data1, string data2, double data3)
        {
            this.data1 = data1 + 1;
            this.data2 = data2 + "atos";
            this.data3 = data3 + 0.5;
        }
        private protected override int Process1()
        {
            return this.data1 - 1;
        }
        private protected override string Process2()
        {
            return this.data2.Remove(this.data2.Length - 5, 4);
        }
        public double GetData3() { return this.data3 - 0.5; }
        public int GetPrivate1() { return Process1();  }
        public string GetPrivate2() { return Process2(); }
    }
    public class ExeptionHadleing
    {
        public void Fail()
        {
            throw new Exception("Error!");
        }
    }

}
