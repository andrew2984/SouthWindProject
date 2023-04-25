using SouthWindProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace SouthWindProject.Controller
{
    public static class CustomerManager
    {
        public static void CreateCustomer(Customer newCustomer)
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }

        }


        public static void DeleteEntry(string customerId)
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                var customer = db.Customers.Find(customerId);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
        public static List<Customer> ReturnListOfCustomers()
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                return db.Customers.ToList();

            }


        }

        public static void Update(string customerId, string customerName, string city, string postCode, string country, List<Order> orders = null)
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                var customer = db.Customers.Where(o => o.CustomerId == customerId).First();
                customer.ContactName = customerName;
                customer.City = city;
                customer.PostalCode = postCode;
                customer.Country = country;
                customer.Orders = orders;
                db.Customers.Update(customer);
                db.SaveChanges();
            }
        }
    }
}
