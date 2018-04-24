using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class CustomerRepository
    {
        private ICustomer context;

        public CustomerRepository()
        {
            context = new CustomerSQLContext();
        }

        public List<Customer> GetAllCustomers()
        {
            return context.GetAllCustomers();
        }

        public Customer GetCustomerByID(int customerID)
        {
            return context.GetCustomerByID(customerID);
        }

        public bool Login(string email, string password)
        {
            return context.Login(email, password);
        }

        public bool Register(string name, string surname, string email, string password, bool admin)
        {
            return context.Register(name, surname, email, password, admin);
        }
    }
}
