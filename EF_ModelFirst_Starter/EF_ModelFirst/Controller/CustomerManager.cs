using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SouthWindProject.Model;
using SouthWindProject.View;

namespace SouthWindProject.Controller
{
    public static class CustomerManager
    {
        private static SouthwindContext db = new SouthwindContext();

        public static void CreateCustomer(Customer newCustomer)
        {
            using (db)
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }

        }


        public static void DeleteEntry(string customerId)
        {
            using (db)
            {
                var customer = db.Customers.Find(customerId);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
        public static List<Customer> ReturnListOfCustomers()
        {
            using (db)
            {
                return db.Customers.ToList();

            }


        }

        public static void Update(ValueTuple<string, string, string, string, string, List<Order>> tuple)
        {
            var customer = db.Customers.Where(o => o.CustomerId == tuple.Item1).First();
            customer.ContactName = tuple.Item2;
            customer.City = tuple.Item3;
            customer.PostalCode = tuple.Item4;
            customer.Country = tuple.Item5;
            customer.Orders = tuple.Item6;
            db.Customers.Update(customer);
            db.SaveChanges();
        }


    }
}
