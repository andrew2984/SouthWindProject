using Microsoft.EntityFrameworkCore;
using SouthWindProject.Controller;
using SouthWindProject.Model;

namespace SouthWindTests
{
    public class Tests
    {
        private Customer _testCustomer;

        [SetUp]
        public void SetUp()
        {
            _testCustomer = new Customer() { ContactName = "Test subject", City = "Test city", PostalCode = "TTT", Country = "TS", CustomerId = "TTTTT" };
            using (var _db = new SouthwindContext())
            {
                _db.Customers.Add(_testCustomer);
                _db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var _db = new SouthwindContext())
            {
                var temp = _db.Customers.Where(e => e.CustomerId == "TTTTT").First();
                _db.Remove(temp);
                _db.SaveChanges();
            }
        }

        [Ignore("primary key conflict ignore for now")]
        [Test]
        public void WhenCustomerIsAddedAmountOfCustomersIncreasesByOne()
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                var test = new Customer() { ContactName = "test subject One", City = "Northampton", PostalCode = "AB1 3ED", Country = "UK", CustomerId = "test" };

                var expectedlist = new List<Customer>() { test };
                var expectedCapacity = 1;

                var actuallistsetup = db.Customers.Add(test);
                var actualCapacity = db.Customers.ToList().Count();
                db.SaveChanges();


                Assert.That(actualCapacity, Is.EqualTo(expectedCapacity));
            }
        }

        [Ignore("primary key ignore for now")]



        [Test]
        public void ReturnListOfCustomersCorrectly()
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                var test = new Customer() { ContactName = "test subject", City = "Northampton", PostalCode = "AB1 3ED", Country = "UK", CustomerId = "JACOB" };
                var expectedlist = new List<Customer>() { test };
                var actuallistsetup = db.Customers.Add(test);
                db.SaveChanges();
                var actuallist = db.Customers.ToList();

                Assert.That(actuallist[0], Is.EqualTo(expectedlist[0]));
            }

        }



        [Ignore("primary key ignore for now")]
        [Test]
        public void WhenReadingCustomersReturnCorrectLengthOfCustomerList()
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                var test = new Customer() { ContactName = "test subject One", City = "Northampton", PostalCode = "AB1 3ED", Country = "UK", CustomerId = "test2" };

                var expectedlist = new List<Customer>() { test };
                var expectedCapacity = expectedlist.Count();

                var actuallistsetup = db.Customers.Add(test);
                var actualCapacity = db.Customers.ToList().Count();
                db.SaveChanges();


                Assert.That(actualCapacity, Is.EqualTo(expectedCapacity));
            }
        }


        [Test]
        public void WhenReadingACustomerReturnCorrectData()
        {
            var actualResult = CustomerManager.ReturnListOfCustomers();
            List<Customer> expectedResult;
            using (SouthwindContext db = new SouthwindContext())
            {
                expectedResult = db.Customers.ToList();
            }
            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }




        [Test]
        public void WhenCustomerUpdated_ThenCustomerUpdated_ReturnNewChanges()
        {
            var testCustUpdate = new Customer() { ContactName = "Test subject UPDATE", City = "Test city", PostalCode = "TTT", Country = "TS", CustomerId = "TTTTT" };
            CustomerManager.Update("TTTTT", "Test subject UPDATE", "Test city", "TTT", "TS");
            string actualResult = "";
            string expectedResult = "Test subject UPDATE";
            using (SouthwindContext db = new SouthwindContext())
            {
                actualResult = db.Customers.Where(e => e.CustomerId == testCustUpdate.CustomerId).First().ContactName;
            }
            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }

    }
}