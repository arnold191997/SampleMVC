using SampleMVC.Models;
using SampleMVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SampleMVC.Services.Method
{
    public class UserService : IUserService
    {
        private string connectionstring { get; set; }
        public UserService()
        {
            connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["Sqlconnection"].ToString();
        }
        public User GetUser(string username, string password)
        {
            User user = new User();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("loginUser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = username;
                        cmd.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = password;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    user = new User();
                                    user.id = int.Parse(reader["ID"].ToString());
                                    user.uid = reader["UID"].ToString();
                                    user.pwd = reader["PWD"].ToString();
                                    user.first_name = reader["FirstName"].ToString();
                                    user.last_name = reader["LastName"].ToString();
                                    user.active = bool.Parse(reader["Active"].ToString());
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return user;
        }

       
    }
}