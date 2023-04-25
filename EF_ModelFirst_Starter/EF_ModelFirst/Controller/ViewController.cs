using SouthWindProject.Model;
using SouthWindProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWindProject.Controller;

public class ViewController
{
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
