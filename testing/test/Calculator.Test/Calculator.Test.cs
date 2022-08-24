using System;
using Xunit;
using Calculators;

namespace Calculator.Test
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(4.2, 5, 9.2)]
        [InlineData(-4,4,0)]
        public void Add(float x, float y,float expected)
        {
            var Calculator = new Calculators.Calculator();
            double actual = Calculator.Add(x, y);

            Assert.Equal(expected, actual);
        }
    }
}
