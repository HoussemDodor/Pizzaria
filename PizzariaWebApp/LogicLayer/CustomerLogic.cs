using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using Models;

namespace LogicLayer
{
    public class CustomerLogic
    {
        private CustomerRepository repo;

        public CustomerLogic()
        {
            repo = new CustomerRepository();
        } 

        public List<Customer> GetAllCustomers()
        {
            return repo.GetAllCustomers();
        }

        public Customer GetCustomerByID(int customerID)
        {
            return repo.GetCustomerByID(customerID);
        }

        public Customer Login(string email, string password)
        {
            return repo.Login(email, password);
        }

        public Customer Register(string name, string surname, string email, string password, bool admin)
        {
            return repo.Register(name, surname, email, password, admin);
        }
    }
}
