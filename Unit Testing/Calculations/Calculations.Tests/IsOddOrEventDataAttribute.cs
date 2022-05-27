using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;
using System.Linq;

namespace Calculations.Tests
{
    public class IsOddOrEventDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            //yield return new object[] { 1, true };
            //yield return new object[] { 200, false };
            var allLines = System.IO.File.ReadAllLines("IsOddOrEvenTestData.txt");
            return allLines.Select(x =>
            {
                var lineSplit = x.Split(',');
                return new Object[] { int.Parse(lineSplit[0]), bool.Parse(lineSplit[1]) };
            });
        }
    }
}
