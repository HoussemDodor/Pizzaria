using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Side : Product
    {
        public int ID { get; set; }
        public decimal buyInPrice { get; set; }
        public bool vegan { get; set; }
        public bool halal { get; set; }
        public bool alcohol { get; set; }
        public int categoryID { get; set; }
    }
}
