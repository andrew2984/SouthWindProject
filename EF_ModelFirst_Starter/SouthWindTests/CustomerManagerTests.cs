using SouthWindProject.Controller;
using SouthWindProject.Model;

namespace SouthWindTests
{
    public class Tests
    {

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


        [Ignore("setup required")]
        [Test]
        public void WhenReadingACustomerReturnCorrectData()
        {
            using (SouthwindContext db = new SouthwindContext())
            {
               
                Assert.That(db.Customers.ToList(), Is.EqualTo(CustomerManager.ReturnListOfCustomers()));
            }

        }




        [Ignore("Needs setup to function")]
        [Test]
        public void WhenCustomerUpdated_ThenCustomerUpdated_ReturnNewChanges()
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                var testCust = new Customer() { ContactName = "Test subject", City = "Test city", PostalCode = "TTT", Country = "TS", CustomerId = "TTTTJ" };
                db.Customers.Add(testCust);
                db.SaveChanges();
                var testCustUpdate = new Customer() { ContactName = "Test subject UPDATE", City = "Test city", PostalCode = "TTT", Country = "TS", CustomerId = "TTTTJ" };
                CustomerManager.Update(testCustUpdate);
                Thread.Sleep(2);
                var actualResult = db.Customers.Where(e => e.CustomerId == "TTTTJ").First().ContactName;
                var expectedResult = "Test subject UPDATE";
                Assert.That(actualResult, Is.EqualTo(expectedResult));

            }

        }

    }
}