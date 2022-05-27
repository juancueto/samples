using System;
using Xunit;

namespace Calculations.Tests
{
    public class NameTest
    {
        public NameTest()
        {
        }

        [Fact]
        public void MakeFullNameTest()
        {
            var names = new Names();
            var result = names.MakeFullName("Juan", "Cueto");

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);

            //Assert.StartsWith("juan", result);
            //Assert.EndsWith("cueto", result, StringComparison.InvariantCultureIgnoreCase);
            //Assert.Contains("Juan", result, StringComparison.InvariantCultureIgnoreCase);
            //Assert.Equal("Juan Cueto", result, ignoreCase:true);
        }

        [Fact]
        public void NickName_MustBeNull()
        {
            var names = new Names();
            names.NickName = "JP";
            //Assert.Null(names.NickName);
            Assert.NotNull(names.NickName);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullName("Juan", "Cueto");
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}
