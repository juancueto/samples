using System;
namespace Calculations
{
    public class Customer
    {
        public string Name => "Juan";
        public int Age => 36;

        public virtual int GetOrdersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Hello");
            }

            return 100;
        }

        public string GetFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
    }
}
