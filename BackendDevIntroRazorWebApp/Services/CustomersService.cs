using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendDevIntroRazorWebApp.Models;

namespace BackendDevIntroRazorWebApp.Services
{
    public static class CustomersService
    {
        static List<Customer> Customers { get; }
        static CustomersService()
        {
            Customers = new List<Customer>
            {
                new Customer { CustomerID = "ABC", CompanyName = "Classic Italian" },
                new Customer { CustomerID = "DEF", CompanyName = "Veggie" }
            };
        }

        public static List<Customer> GetAll() => Customers;

        public static Customer Get(string customerID) => Customers.FirstOrDefault(p => p.CustomerID == customerID);

        public static void Add(Customer customer)
        {
            Customers.Add(customer);
        }

        public static void Delete(string customerID)
        {
            var customer = Get(customerID);
            if (customer is null)
                return;

            Customers.Remove(customer);
        }

        public static void Update(Customer customer)
        {
            var index = Customers.FindIndex(p => p.CustomerID == customer.CustomerID);
            if (index == -1)
                return;

            Customers[index] = customer;

        }
    }
}
