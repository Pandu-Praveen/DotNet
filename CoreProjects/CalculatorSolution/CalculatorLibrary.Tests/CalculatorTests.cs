using System;
using Xunit;
using CalculatorLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator = new Calculator();

        [Fact]
        public void Add_ShouldReturnSum()
        {
            var result = _calculator.Add(3, 5);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_ShouldReturnDifference()
        {
            var result = _calculator.Subtract(10, 4);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiply_ShouldReturnProduct()
        {
            var result = _calculator.Multiply(3, 4);
            Assert.Equal(12, result);
        }

        [Fact]
        public void Divide_ShouldReturnQuotient()
        {
            var result = _calculator.Divide(10, 2);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
        }
    }
}
