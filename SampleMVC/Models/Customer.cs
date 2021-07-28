using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMVC.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string customername { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string status { get; set; }
        public string area { get; set; }
        public string address { get; set; }
        public string addservices { get; set; }
    }
}