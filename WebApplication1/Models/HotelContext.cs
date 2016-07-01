using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Hotel.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Hotel.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext()
            :base("HotelEntities")
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Sale> Sales { get; set; }
   

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasMany(b => b.Bookings)
                .WithMany(s => s.Services)
                .Map(t => t.MapLeftKey("ServiceId")
                .MapRightKey("BookingId")
                .ToTable("ServiceBooking"));
        }
    }
}