using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public Service()
        {
            Bookings = new List<Booking>();
        }
    }

}