using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWindProject
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
            using(db)
            {
                return db.Customers.ToList();
                
            }

           
        }

    }
}
