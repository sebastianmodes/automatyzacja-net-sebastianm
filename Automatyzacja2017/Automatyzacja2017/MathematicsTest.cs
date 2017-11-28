using System;
using Xunit;

namespace Automatyzacja2017
{
    public class MathematicsTest
    {
        [Theory]
        [InlineData(10,11,21)]
        [InlineData(0, 0, 0)]
        public void TheoryExample(double x, double y, double expected)
        {
            var math = new Mathematics();

            var result = math.Add(x, y);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_returns_sum_of_given_values()
        {
            // ararange
            var math = new Mathematics();

            // act
            var result = math.Add(10, 20);

            //assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void Add_returns_sum_of_given_values_double()
        {
            // ararange
            var math = new Mathematics();

            // act
            var result = math.Add(10, 0.5);

            //assert
            Assert.Equal(10.5, result);
        }

        [Fact]
        public void Substract_returns_sum_of_given_values()
        {
            // ararange
            var math = new Mathematics();

            // act
            var result = math.Substract(10, 20);

            //assert
            Assert.Equal(-10, result);
        }

        [Fact]
        public void Substract_returns_sum_of_given_values_double()
        {
            // ararange
            var math = new Mathematics();

            // act
            var result = math.Substract(3, -0.5);

            //assert
            Assert.Equal(3.5, result);
        }

        [Fact]
        public void Multiply_returns_sum_of_given_values()
        {
            // ararange
            var math = new Mathematics();

            // act
            var result = math.Multiple(3, 0.5);

            //assert
            Assert.Equal(1.5, result);
        }

        [Fact]
        public void Multiply_returns_sum_of_given_values_zero()
        {
            // ararange
            var math = new Mathematics();

            // act
            var result = math.Multiple(3, 0);

            //assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Divide_returns_sum_of_given_values_zero()
        {
            // ararange
            var math = new Mathematics();

            // act
            var result = math.Divide(7, 0);

            //assert
            Assert.Equal(0, result);
            //Assert.Throws<DivideByZeroException>(() => math.Divide(7, 0));
        }

        [Fact]
        public void Divide_returns_sum_of_given_values()
        {
            // ararange
            var math = new Mathematics();

            // act
            var result = math.Divide(7, 2);

            //assert
            Assert.Equal(3.5, result);
        }

    }
}
