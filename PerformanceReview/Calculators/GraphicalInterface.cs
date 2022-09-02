using System;
using System.Text.RegularExpresion;
using System.Collections.Generic;


namespace Calculators
{
    internal class GraphicalInterphace
    {
        public bool PowerOn { get; set; }
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

            while(true)
            {
                if (!PowerOn)
                {
                    if (input == "on")
                        this.PowerOn = true;
                    else
                        Console.WriteLine("");
                }
                else
                {
                    if (input == "off")
                        this.PowerOn = false;
                    else
                    {
                        Console.WriteLine(this.C.Value);
                        input = Console.ReadLine();

                        Console.WriteLine(this.C.ProcessInput(ref input, ref this.Q));
                    }
                }
            }
        }
    }
}
