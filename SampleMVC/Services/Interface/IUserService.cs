using SampleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC.Services.Interface
{
    public interface IUserService
    {
        User GetUser(string username, string password);
    }
}
