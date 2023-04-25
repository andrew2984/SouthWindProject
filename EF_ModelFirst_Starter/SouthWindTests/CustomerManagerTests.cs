using SouthWindProject.Model;

namespace SouthWindTests
{
    public class Tests
    {

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

        public void WhenCustomerUpdated_ThenCustomerUpdated_ReturnNewChanges()
        {
            var testCust = new Customer() { ContactName = "Test subject", City = "Test city", PostalCode = "TTT", Country = "UK", CustomerId = "JACOB" }
        }
    }
}