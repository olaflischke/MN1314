using EFDemo.Model;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadCustomers()
        {
            NorthwindContext context = new NorthwindContext();

            var customers = context.Customers.Where(cu => cu.Country == "Germany");

            foreach (var item in customers)
            {
                Console.WriteLine(item.CompanyName);
            }

            Assert.Pass();
        }
    }
}