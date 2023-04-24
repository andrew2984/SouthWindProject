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
        
    }
}
