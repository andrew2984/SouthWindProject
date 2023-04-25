﻿using Microsoft.EntityFrameworkCore;
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
            Seed(db);
            //Customer c = new Customer() { ContactName = "Andrew Ma", City = "Liverpool", PostalCode = "PP0 7AD", Country = "UK", CustomerId = "ANDRM" };
            //CustomerManager.CreateCustomer(c);

        }
    }

    static void Seed(SouthwindContext db)
    {
        //Remove first:

        db.OrderDetails.ExecuteDelete();
        db.SaveChanges();
        db.Orders.ExecuteDelete();
        db.SaveChanges();
        db.Customers.ExecuteDelete();
        db.SaveChanges();

        //Adding:

        List<Customer> customerList = new List<Customer>()
        { new Customer() { ContactName = "Jacob Banyard", City = "Northampton", PostalCode = "AB1 3ED", Country = "UK", CustomerId = "JACOB" },
        new Customer() { ContactName = "Ahmed Bader", City = "London", PostalCode = "LC1 5JY", Country = "UK", CustomerId = "AHMEB" },
        new Customer() { ContactName = "Talal Hassan", City = "London", PostalCode = "LU1 2XD", Country = "UK", CustomerId = "TALAH" }};

        foreach (var c in customerList)
        {
            db.Customers.Add(c);
        }
        db.SaveChanges();

        List<Order> orderList = new List<Order>()
        {
            new Order() { ShipCountry = "USA", ShippedDate = new DateTime(2023, 1, 2), OrderDate = new DateTime(2022, 12, 20), CustomerId = "JACOB" },
            new Order() { ShipCountry = "UK", ShippedDate = new DateTime(2020, 4, 5), OrderDate = new DateTime(2020, 4, 1), CustomerId = "TALAH" },
            new Order() { ShipCountry = "CHINA", ShippedDate = new DateTime(2023, 2, 3), OrderDate = new DateTime(2023, 1, 19), CustomerId = "AHMEB" }
        };

        foreach (var o in orderList)
        {
            db.Orders.Add(o);
        }

        db.SaveChanges();

        List<OrderDetail> orderDetailsList = new List<OrderDetail>()
        {
            new OrderDetail() { OrderId = db.Orders.Where(e=>e.CustomerId == "JACOB").First().OrderId, Discount = 0.05f,Quantity = 10,UnitPrice = 2.00m },
            new OrderDetail() { OrderId = db.Orders.Where(e=>e.CustomerId == "TALAH").First().OrderId, Discount = 0.15f,Quantity = 100,UnitPrice = 14.00m },
            new OrderDetail() { OrderId = db.Orders.Where(e => e.CustomerId == "AHMEB").First().OrderId, Discount = 0.05f,Quantity = 7,UnitPrice = 11.21m }
        };

        foreach (var od in orderDetailsList)
        {
            db.OrderDetails.Add(od);
        }

        db.SaveChanges();
    }
}
