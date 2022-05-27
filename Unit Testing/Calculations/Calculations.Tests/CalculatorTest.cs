using System;
using Xunit;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Calculations.Tests
{
    public class CalculatorFixture: IDisposable
    {

        public Calculator Calc => new Calculator();

        public void Dispose()
        {
            // Clean

        }
    }

    public class CalculatorTest: IClassFixture<CalculatorFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly CalculatorFixture _calculatorFixture;
            

        public CalculatorTest(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _calculatorFixture = calculatorFixture;
        }

        //[Fact]
        //public void TestAdd()
        //{
        //    Assert.Equal(1, 2);
        //}

        [Fact]
        [Trait("Category", "Fibo")]
        public void Add_GivenTwoIntValues_ReturnsSum()
        {
            var calc = _calculatorFixture.Calc; //new Calculator();
            var result = calc.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void Add_GivenTwoDoubleValues_ReturnsSum()
        {
            var calc = _calculatorFixture.Calc; //new Calculator();
            var result = calc.AddDouble(1.23, 3.55);
            Assert.Equal(4.78, result, 2);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckFiboIsNotZero()
        {
            _testOutputHelper.WriteLine("CheckFiboIsNotZero");

            var calc = _calculatorFixture.Calc; //new Calculator();

            Assert.DoesNotContain(0, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotIncludeZero()
        {
            var calc = _calculatorFixture.Calc; //new Calculator();

            Assert.All(calc.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboIncludes13()
        {
            _testOutputHelper.WriteLine("FiboIncludes13");

            var calc = _calculatorFixture.Calc; //new Calculator();

            Assert.Contains(13, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotInclude4()
        {
            var calc = _calculatorFixture.Calc; //new Calculator();

            Assert.DoesNotContain(4, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckCollection()
        {
            _testOutputHelper.WriteLine("CheckFiboNumbers. Test Starting at {0}", DateTime.Now);

            List<int> expectedCollection = new() { 1, 1, 2, 3, 5, 8, 13, 21 };
            var calc = _calculatorFixture.Calc; //new Calculator();

            Assert.Equal(expectedCollection, calc.FiboNumbers);

            _testOutputHelper.WriteLine("End");
        }

        [Fact]
        public void IsOdd_GibenOddValue_ReturnsTrue()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(1);
            Assert.True(result);
        }

        [Fact]
        public void IsOdd_GibenOddValue_ReturnsFalse()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(20);
            Assert.False(result);
        }

        [Theory]
        //[InlineData(1, true)]
        //[InlineData(20, false)]
        //[MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
        //[MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType = typeof(TestDataShare))]
        [IsOddOrEventData]
        public void IsOdd_TestOddAnEven(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
            //Assert.True(expected);
        }
    }
}
