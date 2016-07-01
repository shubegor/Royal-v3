using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int AmountOfDays { get; set; }
        public double Coefficient { get; set; }
    }
}