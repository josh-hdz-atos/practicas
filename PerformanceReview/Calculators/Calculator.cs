using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Calculators
{
    internal class Calculator : Arithmetic
    {
        private float _value;
        public float Value { get {return _value; } set {_value = Value; } }

        public Calculator() { this._value = 0; }

        public void ProcessInput(ref string input, ref Queue<string> tokens)
        {
            string currentToken;
            char token;

            GetTokens(ref input, ref tokens);

            if (!Regex.IsMatch(tokens.Peek(), @"\W"))
            {
                _value = float.Parse(tokens.Peek());
                tokens.Dequeue();
            }

            while (tokens.Count > 0)
            {
                currentToken = tokens.Peek();
                tokens.Dequeue();

                token = Char.Parse(currentToken);
                switch(token)
                {
                    case '-':
                        _value = Sub(_value, float.Parse(tokens.Peek()));
                        break;
                    case '*':
                        _value = Mul(_value, float.Parse(tokens.Peek()));
                        break;
                    case '/':
                        _value = Div(_value, float.Parse(tokens.Peek()));
                        break;
                    case '+':
                        _value = Add(_value, float.Parse(tokens.Peek()));
                        break;
                    default:
                        break;
                }

                tokens.Dequeue();
            }
        }


        private void GetTokens(ref string input, ref Queue<string> tokens)
        {
            if (Regex.IsMatch(input, @"^[-+*/]?\d+([-+*/]+[-+]?\d+)*$"))
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
                            if (number != "")
                            {
                                tokens.Enqueue(number);
                                number = "";
                            }
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

                if (number != "")
                    tokens.Enqueue(number);
            }
            else throw new ArgumentException("Invalid input");

        }
    }
}
