using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using SouthWindProject.Model;
using SouthWindProject.View;

namespace SouthWindProject.Controller;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new SouthwindContext())
        {
            //Seed(db);
            foreach (var item in db.Orders) Console.WriteLine(item.OrderId);
            ViewController.Start(db);
            //Customer c = new Customer() { ContactName = "Andrew Ma", City = "Liverpool", PostalCode = "PP0 7AD", Country = "UK", CustomerId = "ANDRM" };
            //CustomerManager.CreateCustomer(c);
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

        db.OrderDetails.Add(new OrderDetail() { OrderId = db.Orders.Where(e => e.CustomerId == "JACOB").First().OrderId, Discount = 0.05f, Quantity = 10, UnitPrice = 2.00m });
        db.OrderDetails.Add(new OrderDetail() { OrderId = db.Orders.Where(e => e.CustomerId == "TALAH").First().OrderId, Discount = 0.15f, Quantity = 100, UnitPrice = 14.00m });
        db.OrderDetails.Add(new OrderDetail() { OrderId = db.Orders.Where(e => e.CustomerId == "AHMEB").First().OrderId, Discount = 0.05f, Quantity = 7, UnitPrice = 11.21m });

        db.SaveChanges();
    }
}
