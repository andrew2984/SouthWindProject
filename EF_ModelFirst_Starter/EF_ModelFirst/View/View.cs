using SouthWindProject.Controller;
using SouthWindProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SouthWindProject.Controller;
using SouthWindProject.Model;

namespace SouthWindProject.View;

public class View
{
    static void UpdateInput(SouthwindContext db)
    {
        Console.WriteLine("CustomerID of Customer to update?");
        string customerId = Console.ReadLine();
        while (!db.Customers.Select(c => c.CustomerId).Contains(customerId))
        {
            Console.WriteLine("Invalid ID");
            customerId = Console.ReadLine();
        }
        Console.WriteLine("Name?");
        string contactName = Console.ReadLine();
        Console.WriteLine("City?");
        string city = Console.ReadLine();
        Console.WriteLine("Postal Code?");
        string postalCode = Console.ReadLine();
        Console.WriteLine("Country?");
        string country = Console.ReadLine();
        Console.WriteLine("Please list the Order IDs separated by a space.");
        string ordersString = Console.ReadLine();

        var ordersSplit = ordersString.Split(" ");
        var orders = new List<Order>();
        foreach (var item in ordersSplit)
        {
            if (int.TryParse(item, out int orderId) && db.Orders.Select(o => o.OrderId).Contains(orderId))
            {
                orders.Append(db.Orders.Where(o => o.OrderId == orderId).First());
            }
        }
        CustomerManager.Update((customerId, contactName, city, postalCode, country, orders));
    }

    public (string name, string city, string postalCode, string country) AskForCustomerInfo()
    {
        Console.WriteLine("Enter Contact Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter City: ");
        string city = Console.ReadLine();
        Console.WriteLine("Enter PostalCode: ");
        string postalCode = Console.ReadLine();
        Console.WriteLine("Enter Country: ");
        string country = Console.ReadLine(); 
        return (name, city, postalCode, country);  

        //var names = name.Split(' ');
        //string id = "";
        //if (names[0].Length < 5)
        //{
        //    if (names.Length == 1 || names[0].Length < 4)
        //    {
        //        id = names[0];
        //        for (int i = names[0].Length; i < 5; i++)
        //        {
        //            id += 'A';
        //        }
        //    }

        //}
        //else id = names[0].Substring(0, 4) + names[1][0];

        //id = id.ToUpper();
        //var newCustomer = new Customer() { ContactName = name, City = city, PostalCode = postalCode, Country = country, CustomerId = id };
        //CustomerManager.CreateCustomer(newCustomer);

    }
}
