using SampleMVC.Models;
using SampleMVC.Services.Interface;
using SampleMVC.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SampleMVC.Services.Method
{
    public class CustomerService : ICustomerService
    {
        private string connectionstring { get; set; }
        public CustomerService()
        {
            connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["Sqlconnection"].ToString();
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> customerlist = new List<Customer>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("GetCustomers", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var customer = new Customer();
                                    customer.id = int.Parse(reader["CustomerCode"].ToString());
                                    customer.address = reader["Address"].ToString();
                                    customer.addservices = reader["AddService"].ToString();
                                    customer.area = reader["Area"].ToString();
                                    customer.customername = reader["CustName"].ToString();
                                    customer.email = reader["Email"].ToString();
                                    customer.phonenumber = reader["PhoneNumber"].ToString();
                                    customer.status = reader["Status"].ToString();
                                    customerlist.Add(customer);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
            return customerlist;
        }

        public Customer GetCustomerid(int customerid)
        {
            var customer = new Customer();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("GetCustomersById", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = customerid;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    customer = new Customer();
                                    customer.id = int.Parse(reader["CustomerCode"].ToString());
                                    customer.address = reader["Address"].ToString();
                                    customer.addservices = reader["AddService"].ToString();
                                    customer.area = reader["Area"].ToString();
                                    customer.customername = reader["CustName"].ToString();
                                    customer.email = reader["Email"].ToString();
                                    customer.phonenumber = reader["PhoneNumber"].ToString();
                                    customer.status = reader["Status"].ToString();
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return customer;
        }

        public List<Service> getservices()
        {
            List<Service> servicelist = new List<Service>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("GetServices", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var Service = new Service();
                                    Service.servicecode = int.Parse(reader["ServiceCode"].ToString());
                                    Service.servicename = reader["ServiceName"].ToString();
                                    servicelist.Add(Service);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return servicelist;
        }

        public void insertcustomer(Customer customer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("InsertCustomer", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customername", SqlDbType.NVarChar).Value = customer.customername;
                        cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = customer.email;
                        cmd.Parameters.AddWithValue("@phonenumber", SqlDbType.NVarChar).Value = customer.phonenumber;
                        cmd.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = customer.status;
                        cmd.Parameters.AddWithValue("@area", SqlDbType.NVarChar).Value = customer.area;
                        cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = customer.address;
                        cmd.Parameters.AddWithValue("@services", SqlDbType.NVarChar).Value = customer.addservices;
                        cmd.ExecuteNonQuery();
                       
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void updatecustomer(Customer customer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateCustomer", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@custid", SqlDbType.BigInt).Value = customer.id;
                        cmd.Parameters.AddWithValue("@customername", SqlDbType.NVarChar).Value = customer.customername;
                        cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = customer.email;
                        cmd.Parameters.AddWithValue("@phonenumber", SqlDbType.NVarChar).Value = customer.phonenumber;
                        cmd.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = customer.status;
                        cmd.Parameters.AddWithValue("@area", SqlDbType.NVarChar).Value = customer.area;
                        cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = customer.address;
                        cmd.Parameters.AddWithValue("@services", SqlDbType.NVarChar).Value = customer.addservices;
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void deletecustomer(int customerid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("deleteCustomer", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@custid", SqlDbType.BigInt).Value = customerid;
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}