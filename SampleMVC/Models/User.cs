using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMVC.Models
{
    public class User
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }
        public string uid { get; set; }
        public string pwd { get; set; }

        public bool active { get; set; }
    }
}