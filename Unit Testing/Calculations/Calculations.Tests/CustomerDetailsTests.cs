using System;
using Xunit;
namespace Calculations.Tests
{
    [Collection("Customer")]
    public class CustomerDetailsTests
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerDetailsTests(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void GetFullName_GivenFirstNameAndLastName_ReturnsFullName()
        {
            var customer = _customerFixture.Cust; // new Customer();
            Assert.Equal("Juan Cueto", customer.GetFullName("Juan", "Cueto"));
        }
    }
}
