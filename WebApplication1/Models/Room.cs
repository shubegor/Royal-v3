using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Category { get; set; }
        public double Price { get; set; }
        public ICollection<Booking> Bookings {get; set;}
        public Room()
        {
            Bookings = new List<Booking>();
        }
    }
}