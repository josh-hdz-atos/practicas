namespace Calculators
{
    internal class Calculator
    {
        private float _value;

        internal float Add(float x)
        {
            _value += x;
            return _value;
        }

        internal float Sub(float x)
        {
            _value -= x;
            return _value;
        }

        internal float Mul(float x)
        {
            _value *= x;
            return _value;
        }

        internal float Div(float x)
        {
            if (x == 0) _value = 0;
            else _value /= x;

            return _value;
        }
    }
}
