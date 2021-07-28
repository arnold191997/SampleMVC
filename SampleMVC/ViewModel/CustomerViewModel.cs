using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMVC.Models;

namespace SampleMVC.ViewModel
{
    public class CustomerViewModel
    {
        public int customerid { get; set; }

        [Required, StringLength(150)]
        [Display(Name ="Customer Name")]
        public string customername { get; set; }

        [Required, StringLength(150)]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Phone Number")]
        [Required, StringLength(15)]
        public string phonenumber { get; set; }
 

        [Required, StringLength(20)]
        [Display(Name = "Status")]
        public string status { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Area")]
        public string area { get; set; }

        [Required, StringLength(250)]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Add Services")]
        public List<SelectListItem> addservices { get; set; }
      
        public string customercode { get; set; }
    }
}