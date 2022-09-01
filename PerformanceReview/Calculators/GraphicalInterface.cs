using System;
using System.Text.RegularExpresion;
using System.Collections.Generic;


namespace Calculators
{
    internal class GraphicalInterphace
    {
        public bool PowerOn { get; set; }
        private Calculator c;
        private Queue<char> q
        {
            get { return q; }
            set
            {
                if (Regex.IsMatch(@"^\s*([-+]?)(\d+)(?:\s*([-+*\/])\s*((?:\s[-+])?\d+)\s*)+$", this.input)
                {
                    string number = "";

                    foreach (char ltr in this.input)
                    {
                        switch(ltr)
                        {
                            case '+':
                            case '-':
                            case '*':
                            case '/':
                                this.q.Enqueue((Int32.Parse(number)));
                                number = "";
                                this.q.Enqueue(ltr);
                                break;
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                            case '0':
                                number += ltr;        
                                break;

                        }
                   }
                }
                else throw new ArgumentException("Invalid token");
            }
        }
        private string input;

        GraphicalInterphace()
        {
            PowerOn = true;
            input = "";
            c = new Calculator();
            q = new Queue<char>();

            On();
        }

        public void On()
        {
            while(this.PowerOn)
            {
                Console.WriteLine(c.Value);
                input = Console.ReadLine();

                input.Remove(' ');
                GetTokens(input);
            }
        }


    }
}
