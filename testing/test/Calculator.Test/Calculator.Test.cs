using System;
using Xunit;
using Calculators;

namespace Calculators.Test
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(4.2, 5, 9.2)]
        [InlineData(-4,4,0)]
        public void Add_Simplevalues(float x, float y,float expected)
        {
            var Calculator = new Calculator();
            double actual = Calculator.Add(x, y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 3, -1)]
        [InlineData(5, 3.2, 1.8)]
        [InlineData(-4, 4, -8)]
        [InlineData(-2, -2, 0)]
        public void Sub_SimpleValues(float x, float y, float expected)
        {
            var Calculator = new Calculators.Calculator();
            double actual = Calculator.Sub(x, y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(5, 3.9, 19.5)]
        [InlineData(-4, 4, -16)]
        [InlineData(-2, -2, 4)]
        [InlineData(16, 0, 0)]
        public void Mu_Simplevalues(float x, float y, float expected)
        {
            var Calculator = new Calculators.Calculator();
            double actual = Calculator.Mul(x, y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 5, 0.4)]
        [InlineData(5, 3.9, 1.2820512056350708)]
        [InlineData(4, 4, 1)]
        [InlineData(2, -16, -0.125)]
        [InlineData(15, 5, 3)]
        public void Div_SimpleValues(float x, float y, float expected)
        {
            var Calculator = new Calculators.Calculator();
            double actual = Calculator.Div(x, y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Div_ExeptionDivByZero()
        {
            var Calculator = new Calculators.Calculator();

            Assert.Throws<DivideByZeroException>(() => { Calculator.Div(4, 0); });
        }
    }
}
