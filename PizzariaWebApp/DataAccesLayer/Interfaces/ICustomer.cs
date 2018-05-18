using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal interface ICustomer
    {
        Customer Register(string name, string surname, string email, string password, bool admin);
        Customer Login(string email, string password);
        List<Customer> GetAllCustomers();
        Customer GetCustomerByID(int customerID);
    }
}
