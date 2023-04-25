using SouthWindProject.Controller;
using SouthWindProject.Model;

namespace SouthWindTests
{
    public class Tests
    {
        [Ignore("")]
        [Test]
        public void ReturnListOfCustomersCorrectly()
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                var jacob = new Customer() { ContactName = "test subject", City = "Northampton", PostalCode = "AB1 3ED", Country = "UK", CustomerId = "JACOB" };
                var expectedlist = new List<Customer>() { jacob };
                var actuallistsetup = db.Customers.Add(jacob);
                db.SaveChanges();
                var actuallist = db.Customers.ToList();

                Assert.That(actuallist[0], Is.EqualTo(expectedlist[0]));
            }

        }

        [Test]
        public void WhenCustomerUpdated_ThenCustomerUpdated_ReturnNewChanges()
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                var testCust = new Customer() { ContactName = "Test subject", City = "Test city", PostalCode = "TTT", Country = "TS", CustomerId = "TTTTG" };
                db.Customers.Add(testCust);
                db.SaveChanges();
                var testCustUpdate = new Customer() { ContactName = "Test subject UPDATE", City = "Test city", PostalCode = "TTT", Country = "TS", CustomerId = "TTTTG" };
                CustomerManager.Update(testCustUpdate);
                var actualResult = db.Customers.Where(e => e.CustomerId == "TTTTP").First().ContactName;
                var expectedResult = "Test subject UPDATE";
                Assert.That(expectedResult,Is.EqualTo(actualResult));
                
            }

        }
    }
}