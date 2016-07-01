using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public double Cost { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<Service> Services { get; set; }
        public Booking ()
        {
            Services = new List<Service>();
        }
    }
}