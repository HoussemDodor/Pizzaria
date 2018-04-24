using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal class CustomerSQLContext : ICustomer
    {
        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByID(int customerID)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(string name, string surname, string email, string password, bool admin)
        {
            throw new NotImplementedException();
        }
    }
}
