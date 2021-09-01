using System;
using Xunit;
using WindowsFormCalculator;

namespace XUnitTestProj2XCalc
{
    public class UnitTest1
    {
        [Fact]
        public void Return0_GetEmpty()
        {
           int result= WindowsFormCalculator.StringSum.Add("");
            Assert.Equal(0, result);
        }
        [Theory]
        [InlineData(4,"2,2")]
        [InlineData(3,"1,2")]
        [InlineData(5,"1,2,2")]
        [InlineData(6, "1,2,2,1")]
        public void ReturnSum_GivenNumbers(int expected, string input)
        {
            int result = StringSum.Add(input);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(36,"11\n2,23")]
        [InlineData(3, "//;\n1;2")]
        public void ReturnSum_GivenNewLine(int expected, string input)
        {
            int result = StringSum.Add(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ThrowException_GivenNegativeNumber()
        {
            void testCode() => StringSum.Add("-1,-4,7");
            var exception = Assert.Throws<NegativesNotAllowedException>((Action)testCode);
            Assert.Contains("-1", exception.Message);
            Assert.Contains("-4", exception.Message);
            Assert.DoesNotContain("-7", exception.Message);
        }

    }
}
