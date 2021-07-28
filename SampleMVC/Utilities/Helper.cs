using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleMVC.Models;
using SampleMVC.ViewModel;

namespace SampleMVC.Utilities
{
    public static class Helper
    {
        public static Customer generatecustomerclass(CustomerViewModel model)
        {
            Customer customer = new Customer()
             {
                 id = model.customerid,
                 address = model.address,
                 addservices = String.Join(",", model.addservices.Where(x => x.Selected == true).Select(x => x.Value)),
                 area = model.area,
                 customername = model.customername,
                 email = model.email,
                 phonenumber = model.phonenumber,
                 status = model.status
             };
            return customer;
        }

    }
}