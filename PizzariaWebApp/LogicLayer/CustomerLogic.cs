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

        public List<Customer> GetAllCustomers() => repo.GetAllCustomers();

        public Customer GetCustomerByID(int customerID) => repo.GetCustomerByID(customerID);

        public Customer Login(string email, string password) => repo.Login(email, password);

        public Customer Register(string name, string surname, string email, string password, bool admin) => repo.Register(name, surname, email, password, admin);

        public void UpdateCustomer(Customer c) => repo.UpdateCustomer(c.ID, c.name, c.surName, c.mail);

        public bool CheckIfEmailIsTaken(string email) => repo.CheckIfEmailIsTaken(email);
    }
}
