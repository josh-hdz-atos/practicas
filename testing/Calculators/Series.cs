namespace Calculators
{
    public class Series
    {
        private readonly ICalculator _calculator;

        public Series(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public int Factorial(int n)
        {
            if (n > 1)
                return _calculator.Mul(n, Factorial(n - 1));
            return n;
        }

        public int Fibonacci(int n)
        {
            if (n > 1)
                return _calculator.Add(Fibonacci(n - 1), Fibonacci(n - 2));
            return n;
        }

    }
}