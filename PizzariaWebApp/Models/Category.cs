using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {
        public int ID { get; set; }
        public string name { get; set; }

        public Category(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }
        public Category(string name)
        {
            this.name = name;
        }
    }
}
