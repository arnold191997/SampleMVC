using SampleMVC.Models;
using SampleMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC.Services.Interface
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();

        Customer GetCustomerid(int customerid);

        void insertcustomer(Customer customer);

        List<Service> getservices();

        void updatecustomer(Customer customer);

        void deletecustomer(int customerid);

    }
}
