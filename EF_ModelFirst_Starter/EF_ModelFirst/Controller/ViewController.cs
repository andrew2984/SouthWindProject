using SouthWindProject.Model;
using SouthWindProject.Model;
using SouthWindProject.View;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWindProject.Controller;

public class ViewController
{
    public static void Start(SouthwindContext db)
    {
        View.View.Greeting();
        MenuController(db);
    }

    public static void MenuController(SouthwindContext db)
    {
        bool repeat = true;
        while (repeat)
        {
            View.View.Menu();

            if (int.TryParse(Console.ReadLine(), out int intInput) && intInput > 0 && intInput < 6)
            {
                switch (intInput)
                {
                    case 1:
                        CreateCustomer();
                        break;
                    case 2:
                        ReadCustomers();
                        break;
                    case 3:
                        View.View.UpdateInput(db);
                        break;
                    case 4:
                        string customerId = View.View.GetID(db, "delete");
                        CustomerManager.DeleteEntry(customerId);
                        break;
                    case 5:
                        repeat = false;
                        break;
                }
            }
            else View.View.MenuWrong();
        }
    }

    public static void UpdateLogic(SouthwindContext db, ValueTuple<string, string, string, string, string, string> tuple)
    {
        var ordersSplit = tuple.Item6.Split(" ");
        var orders = new List<Order>();
        foreach (var item in ordersSplit)
        {
            if (int.TryParse(item, out int orderId) && db.Orders.Select(o => o.OrderId).Contains(orderId))
            {
                orders.Append(db.Orders.Where(o => o.OrderId == orderId).First());
            }
        }
        CustomerManager.Update((tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, orders));
    }

    public static void ReadCustomers()
    {
        var list = CustomerManager.ReturnListOfCustomers();
    }

    public static void CreateCustomer()
    {
        var details = new View.View().AskForCustomerInfo();
        var names = details.name.Split(' ');

        string id = GenerateID(names);

        var newCustomer = new Customer() { ContactName = details.name, City = details.city, PostalCode = details.postalCode, Country = details.country, CustomerId = id };
        CustomerManager.CreateCustomer(newCustomer);
    }

    private static string GenerateID(string[] names)
    {
        string id = "";
        if (names[0].Length < 5)
        {
            if (names.Length == 1 || names[0].Length < 4)
            {
                id = names[0];
                for (int i = names[0].Length; i < 5; i++)
                {
                    id += (char)new Random().Next(65, 122);
                }
            }

        }
        else id = names[0].Substring(0, 4) + names[1][0];

        return id.ToUpper();
    }
}