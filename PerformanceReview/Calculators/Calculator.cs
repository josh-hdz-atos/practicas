using System;
using System.Text.RegularExpresions;
using System.Collections.Generic;

namespace Calculators
{
    internal class Calculator : Arithmetic
    {
        private float _value;
        public float Value { get {return _value; } set {_value = Value; } }

        public Calculator() { this._value = 0; }

        public float ProcessInput(ref string input, ref Queue<string> tokens)
        {
            string currentToken;

            GetTokens(ref input, ref tokens);

            while (tokens.Count > 0)
            {
                currentToken = tokens.Peek();
                tokens.Dequeue();

                if (Pegex.IsMatch(@"\W", currentToken))
                    switch(currentToken)
                    {
                        case "+":
                            Add(_value, tokens.Peek());
                            break;
                        case "-":
                            Sub(_value, tokens.Peek());
                            break;
                        case "*":
                            Mul(_value, tokens.Peek());
                            break;
                        case "/":
                            Div(_value, tokens.Peek());
                            break;
                    }

                tokens.Dequeue();
            }

            return _value;
        }


        private void GetTokens(ref string input, ref Queue<string> tokens)
        {
            if (Regex.IsMatch(@"^\s*([-+]?)(\d+)(?:\s*([-+*\/])\s*((?:\s[-+])?\d+)\s*)+$", input))
            {
                string number = "";

                foreach (char ltr in input)
                {
                    switch(ltr)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            tokens.Enqueue((Int32.Parse(number)));
                            number = "";
                            tokens.Enqueue(ltr.ToString());
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

                if (number != "") tokens.Enqueue(number);
            }
            else throw new ArgumentException("Invalid input");


        }

        private float DoMath(ref Queue<string> tokens)
        {
        }
    }
}
