using Microsoft.Extensions.Configuration;
using RandomCompany.CustomerDetails.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace RandomCompany.CustomerDetails.WebApp.Repositories
{
    public class CustomerDetailRepositories
    {
        private readonly string _connectionString;
        public CustomerDetailRepositories(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<Customer> GetAllCustomers()
        {
            using IDbConnection con = new SqlConnection(_connectionString);
            var sqlQuery = "SELECT * FROM CustomerDetails";
            return (List<Customer>)con.Query<Customer>(sqlQuery);
        }

        public Customer CreateNewCustomer(Customer customer)
        {
            using IDbConnection con = new SqlConnection(_connectionString);
            var insertQuery = "INSERT INTO CustomerDetails(FirstName, LastName, Email, Address)  VALUES(@FirstName,@LastName,@Email,@Address)";

            con.Execute(insertQuery, new
            {
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.Address
            });
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            using IDbConnection con = new SqlConnection(_connectionString);
            string updateQuery = "UPDATE CustomerDetails SET FirstName =@FirstName,LastName=@LastName,Email=@Email,Address=@Address WHERE Id=@Id";
            con.Execute(updateQuery, new
            {
                customer.Id,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.Address
            });
        }

        public void DeleteCustomer(int id)
        {
            using IDbConnection con = new SqlConnection(_connectionString);
            string deleteQuery = "DELETE FROM CustomerDetails WHERE Id=@Id ";
            con.Execute(deleteQuery, new
            {
                Id = id
            });
          
        }
    }
}
