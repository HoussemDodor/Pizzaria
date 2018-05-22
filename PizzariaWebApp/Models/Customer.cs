using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer
    {     
        public int ID { get; set; }
        [EmailAddress][Display(Name = "Email")]
        public string mail { get; set; }
        [Display(Name = "Naam")]
        public string name { get; set; }
        [Display(Name = "Achternaam")]
        public string surName { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        [ScaffoldColumn(false)]
        public bool admin { get; set; }
        public List<Order> OrdersByCustomer { get; set; }

        public override string ToString()
        {
            return name + surName;
        }
    }
}
