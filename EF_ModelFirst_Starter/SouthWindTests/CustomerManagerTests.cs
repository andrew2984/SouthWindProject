using Microsoft.EntityFrameworkCore;
using SouthWindProject.Controller;
using SouthWindProject.Model;

namespace SouthWindTests
{
    public class Tests
    {
        private SouthwindContext _db;
        private Customer _testCustomer;

        [SetUp]
        public void SetUp()
        {
            _testCustomer = new Customer() { ContactName = "Test subject", City = "Test city", PostalCode = "TTT", Country = "TS", CustomerId = "TTTTT" };
            _db = new SouthwindContext();
            _db.Database.OpenConnection();
            _db.Customers.Add(_testCustomer);
            _db.SaveChanges();
            _db.Database.CloseConnection();
        }

        [TearDown]
        public void TearDown()
        {
            _db.Database.OpenConnection();
            _db.Customers.Remove(_testCustomer);
            _db.SaveChanges();
            _db.Database.CloseConnection();
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
            CustomerManager.Update(testCustUpdate);
            using (SouthwindContext db = new SouthwindContext())
            {
                var actualResult = db.Customers.Where(e => e.CustomerId == "TTTTT").First().ContactName;
                var expectedResult = "Test subject UPDATE";
                Assert.That(actualResult, Is.EqualTo(expectedResult));
            }

        }

    }
}