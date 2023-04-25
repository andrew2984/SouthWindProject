using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SouthWindProject;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new SouthwindContext())
        {
            //Seed(db);
            //Customer c = new Customer() { ContactName = "Andrew Ma", City = "Liverpool", PostalCode = "PP0 7AD", Country = "UK", CustomerId = "ANDRM" };
            //CustomerManager.CreateCustomer(c);
            CreateCustomer();
            //CustomerManager.DeleteEntry("BOBAAA");
        }
    }

    static void Seed(SouthwindContext db)
    {
        db.Customers.Add(new Customer() { ContactName = "Jacob Banyard", City = "Northampton", PostalCode = "AB1 3ED", Country = "UK", CustomerId = "JACOB" });
        db.Customers.Add(new Customer() { ContactName = "Ahmed Bader", City = "London", PostalCode = "LC1 5JY", Country = "UK", CustomerId = "AHMEB" });
        db.Customers.Add(new Customer() { ContactName = "Talal Hassan", City = "London", PostalCode = "LU1 2XD", Country = "UK", CustomerId = "TALAH" });

        db.SaveChanges();

        db.Orders.Add(new Order() { ShipCountry = "USA", ShippedDate = new DateTime(2023, 1, 2), OrderDate = new DateTime(2022, 12, 20), CustomerId = "JACOB" });
        db.Orders.Add(new Order() { ShipCountry = "UK", ShippedDate = new DateTime(2020, 4, 5), OrderDate = new DateTime(2020, 4, 1), CustomerId = "TALAH" });
        db.Orders.Add(new Order() { ShipCountry = "CHINA", ShippedDate = new DateTime(2023, 2, 3), OrderDate = new DateTime(2023, 1, 19), CustomerId = "AHMEB" });

        db.SaveChanges();

        db.OrderDetails.Add(new OrderDetail() { OrderId = db.Orders.Where(e=>e.CustomerId == "JACOB").First().OrderId, Discount = 0.05f,Quantity = 10,UnitPrice = 2.00m });
        db.OrderDetails.Add(new OrderDetail() { OrderId = db.Orders.Where(e=>e.CustomerId == "TALAH").First().OrderId, Discount = 0.15f,Quantity = 100,UnitPrice = 14.00m });
        db.OrderDetails.Add(new OrderDetail() { OrderId = db.Orders.Where(e => e.CustomerId == "AHMEB").First().OrderId, Discount = 0.05f,Quantity = 7,UnitPrice = 11.21m });

        db.SaveChanges();
    }

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
        foreach(var item in ordersSplit)
        {
            if (int.TryParse(item, out int orderId) && db.Orders.Select(o => o.OrderId).Contains(orderId))
            {
                orders.Append(db.Orders.Where(o => o.OrderId == orderId).First());
            }
        }
        CustomerManager.Update((customerId, contactName, city, postalCode, country, orders));
    }

    public static void CreateCustomer()
    {
        Console.WriteLine("Enter Contact Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter City: ");
        string city = Console.ReadLine();
        Console.WriteLine("Enter PostalCode: ");
        string postalCode = Console.ReadLine();
        Console.WriteLine("Enter Country: ");
        string country = Console.ReadLine();

        var names = name.Split(' ');
        string id = "";
        if (names[0].Length < 5)
        {
            if (names.Length == 1 || names[0].Length < 4) 
            {
                id = names[0];
                for (int i = names[0].Length; i < 5; i++)
                {
                    id += 'A';
                }
            }

        }
        else id = names[0].Substring(0, 4) + names[1][0];

        id = id.ToUpper();
        var newCustomer = new Customer() { ContactName = name, City = city, PostalCode = postalCode, Country = country, CustomerId = id };
        CustomerManager.CreateCustomer(newCustomer);

    }
}
