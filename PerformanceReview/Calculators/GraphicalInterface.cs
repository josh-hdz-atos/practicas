using System;
using System.Collections.Generic;


namespace Calculators
{
    internal class GraphicalInterphace
    {
        public bool PowerOn;
        private Queue<string> Q;
        private Calculator C;

        public GraphicalInterphace()
        {
            PowerOn = true;
            Q = new Queue<string>();
            C = new Calculator();

            Main();
        }

        private void Main()
        {
            string input = "";

            try
            {
                while (true)
                {
                    if (!PowerOn)
                    {
                        input = Console.ReadLine();
                        if (input == "on")
                            this.PowerOn = true;
                        else
                            Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine(this.C.Value);
                        input = Console.ReadLine();

                        if (input == "off")
                            this.PowerOn = false;
                        else
                            this.C.ProcessInput(ref input, ref this.Q);
                    }
                }
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                Main();
            }
        }
    }
}
