using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendDevIntroRazorWebApp.Models;
using Microsoft.Data.SqlClient;

namespace BackendDevIntroRazorWebApp.Services
{
    public static class CustomersService
    {
        static List<Customer> Customers { get; }
        static CustomersService()
        {
            Customers = new List<Customer>();
        }

        public static List<Customer> GetAll()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                String sql = "SELECT CustomerID, CompanyName FROM Customers";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.CustomerID = reader.GetString(0);
                            customer.CompanyName = reader.GetString(1);
                            Customers.Add(customer);
                        }
                    }
                }
                return Customers;
            }
        }
    }
}
