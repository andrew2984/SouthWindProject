using SouthWindProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static void Update(Customer updatedCustomerInfo)
        {
            var oldCustomerInfo = db.Customers.Where(o => o.CustomerId == updatedCustomerInfo.CustomerId).First();
            oldCustomerInfo = updatedCustomerInfo;
            db.Customers.Update(oldCustomerInfo);
            db.SaveChanges();
        }


    }
}
