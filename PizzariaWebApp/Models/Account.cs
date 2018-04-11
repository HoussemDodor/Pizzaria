using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account
    {     
        public int ID { get; set; }
        public string mail { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
        List<Order> orderListByAccount { get; set; }

        public Account(int ID, string mail, string name, string surName, string password, bool admin)
        {
            this.ID = ID;
            this.mail = mail;
            this.name = name;
            this.surName = surName;
            this.password = password;
            this.admin = admin;
        }

        public Account(string mail, string name, string surName, string password, bool admin)
        {
            this.mail = mail;
            this.name = name;
            this.surName = surName;
            this.password = password;
            this.admin = admin;
        }
    }
}
