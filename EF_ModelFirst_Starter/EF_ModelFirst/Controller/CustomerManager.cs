using SouthWindProject.Model;
using System;
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

        public static void Update(Customer customer)
        {
            using (SouthwindContext db = new SouthwindContext())
            {
                var upCustomer = db.Customers.Where(o => o.CustomerId == customer.CustomerId).First();
                
                db.Customers.Update(customer);
                db.SaveChanges();
            }
            foreach (var item in customer.Orders) Console.WriteLine($"HEEEEEEERE: {item.OrderId}");
        }


    }
}
