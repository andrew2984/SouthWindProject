using SouthWindProject.Controller;
using SouthWindProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SouthWindProject.View;

public class View
{
    public static void Greeting()
    {
        Line();
        Console.WriteLine("Welcome to the SouthWind database manager");

    }

    public static void Menu()
    {
        Line();
        Console.WriteLine("Would would you like to do?");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read");
        Console.WriteLine("3. Update");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Exit");
        Line();
    }

    public static void UpdateInput(SouthwindContext db)
    {
        string customerId = GetID(db, "update");
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

        ViewController.UpdateLogic(db, (customerId, contactName, city, postalCode, country, ordersString));
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
    }

    public static void Line()
    {
        Console.WriteLine("----------------------------------------------------");
    }

    public static void MenuWrong()
    {
        Line();
        Console.WriteLine("Invalid input. Please enter an integer with a corresponding selection.");
    }

    public static string GetID(SouthwindContext db, string edit)
    {
        Console.WriteLine($"CustomerID of Customer to {edit}?");
        string customerId = Console.ReadLine();
        while (!db.Customers.Select(c => c.CustomerId).Contains(customerId))
        {
            Console.WriteLine("Invalid ID");
            customerId = Console.ReadLine();
        }
        return customerId;
    }

    public static void PrintRead(List<Customer> list)
    {
        foreach (var item in list)
        {
            Line();
            Console.WriteLine($"ID: {item.CustomerId}\n   Name: {item.ContactName}\n   Address: {item.City} {item.PostalCode} {item.Country}\n   Orders:");
            foreach (var item2 in item.Orders)
            {
                Console.WriteLine($"      {item2.OrderId}");
            }

        }
    }

    public static void Goodbye()
    {
        Console.WriteLine("Thanks for using me!\nGoodbye!");
    }
}