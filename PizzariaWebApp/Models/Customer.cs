using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {     
        public int ID { get; set; }
        public string mail { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
        List<Order> OrdersByCustomer { get; set; }
    }
}
