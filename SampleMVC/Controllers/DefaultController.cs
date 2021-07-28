using SampleMVC.Models;
using SampleMVC.Services.Interface;
using SampleMVC.Utilities;
using SampleMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SampleMVC.Controllers
{
    public class DefaultController : Controller
    {
        readonly ICustomerService customerService;

        public DefaultController(ICustomerService Service)
        {
            this.customerService = Service;
        }

        // GET: Default
        public ActionResult Dashboard()
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                var customerlist = customerService.GetCustomers().Select(item => new CustomerViewModel()
                {
                    customerid = item.id,
                    address = item.address,
                    area = item.area,
                    customername = item.customername,
                    customercode = AesOperation.encrypt(item.id.ToString()),
                    email = item.email,
                    phonenumber = item.phonenumber,
                    status = item.status
                }).ToList();
                return View(customerlist);
            }
            else
            {
                return this.RedirectToAction("Index", "Home");
            }



        }

        public ActionResult Customer(string id = "")
        {

            User user = (User)Session["user"];
            if (user != null)
            {
                CustomerViewModel customerView = new CustomerViewModel();
                int customerID = 0;
                int.TryParse(AesOperation.Decrypt(id), out customerID);
                customerView.addservices = customerService.getservices().Select(item => new SelectListItem()
                {
                    Value = item.servicecode.ToString(),
                    Text = item.servicename
                }).ToList();
                if (customerID != 0)
                {
                    Customer customer = customerService.GetCustomerid(customerID);
                    customerView.customerid = customer.id;
                    customerView.address = customer.address;
                    customerView.area = customer.area;
                    customerView.customername = customer.customername;
                    customerView.email = customer.email;
                    customerView.phonenumber = customer.phonenumber;
                    customerView.status = customer.status;
                    customerView.customercode = AesOperation.encrypt(customer.id.ToString());
                    if (customer.addservices != "")
                    {
                        var serviceID = customer.addservices.Split(',').ToList();
                        foreach (var y in serviceID)
                        {
                            customerView.addservices.Where(x => x.Value == y).ToList().ForEach(b => b.Selected = true);
                        }
                    }
                }

                return View(customerView);
            }
            else
            {
                return this.RedirectToAction("Index", "Home");
            }


        }

        [HttpPost]
        public ActionResult Customer(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = Helper.generatecustomerclass(model);                   
                if (model.customerid > 0)
                {
                    customerService.updatecustomer(customer);

                }
                else
                {
                    customerService.insertcustomer(customer);
                }
                return this.RedirectToAction("Dashboard", "Default");
            }
            return View(model);
        }

        public ActionResult Delete(string id = "")
        {
            User user = (User)Session["user"];
            if (user != null)
            {

                int customerID = 0;
                int.TryParse(AesOperation.Decrypt(id), out customerID);
                if (customerID > 0)
                {
                    customerService.deletecustomer(customerID);
                }
                return this.RedirectToAction("Dashboard", "Default");
            }
            else
            {
                return this.RedirectToAction("Index", "Home");
            }

        }
    }
}