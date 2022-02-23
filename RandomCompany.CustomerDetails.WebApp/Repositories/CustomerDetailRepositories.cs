using RandomCompany.CustomerDetails.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RandomCompany.CustomerDetails.WebApp.Repositories
{
    public class CustomerDetailRepositories
    {
        readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = CustomerDb; Integrated Security = True; Pooling=False";
        
        public List<Customer> GetCustomerDetails()
        {
            List<Customer> customerList = new();

            using SqlConnection con = new(connectionString);
            SqlCommand cmd = new("SELECT * FROM CustomerDetails", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Customer customer = new();
                customer.Id = Convert.ToInt32(dr["Id"]);
                customer.FirstName = dr["FirstName"].ToString();
                customer.LastName = dr["LastName"].ToString();
                customer.Email = dr["Email"].ToString();
                customer.Address = dr["Address"].ToString();
                customerList.Add(customer);
            }
            return customerList;

        }

        public bool CreateNewCustomer(Customer customer)
        {
            using SqlConnection con = new(connectionString);
            var insertQuery = "INSERT INTO CustomerDetails(FirstName, LastName, Email, Address)  VALUES(' "+ customer.FirstName +"  ', '  " + customer.LastName + " ',   ' " + customer.Email + " ', ' " + customer.Address + " ' )";                                                                                                                                                                                             
            SqlCommand cmd = new(insertQuery, con);
            //cmd.CommandType= CommandType.Text;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            using SqlConnection con = new(connectionString);
            string updateQuery = "UPDATE CustomerDetails SET FirstName ='" + customer.FirstName + "',LastName='"+customer.LastName+"',Email='"+customer.Email+"',Address='"+customer.Address+"' ";
            SqlCommand cmd = new(updateQuery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i >= 1)
                return true ;
            else
                return false;
        }

        public bool DeleteCustomer(int id)
        {
            using SqlConnection con = new(connectionString);
            string deleteQuery = "DELETE FROM CustomerDetails WHERE Id = " + id;
            SqlCommand cmd = new(deleteQuery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if( i >= 1)
                return true;
            else
                return false;
        }
    }
}
