﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DoughType
    {
        public int ID { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal buyInPrice { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
