using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class Product
    {
        [Display(Name = "Naam")]
        public string Name
        {
            get
            {
                return ToString();
            }
            set
            {

            }
        }
        [Display(Name = "Prijs")]
        [DataType(DataType.Currency)]
        public decimal Price
        {
            get
            {
                return GetPrice();
            }
        }

        public abstract decimal GetPrice();
    }
}
