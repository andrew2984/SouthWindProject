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

        public static List<Customer> ReturnListOfCustomers()
        {
            using(db)
            {
                return db.Customers.ToList();
                
            }

           
        }
        
    }
}
