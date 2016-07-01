using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Hotel.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Hotel.Models
{
    public class HotelDbInitializer : DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext db)
        {
            //создание комнат
            var room1 = new Room
            {
                Amount = 3,
                Category = 1,
                Price = 2200
            };
            
            var room2 = new Room
            {
                Amount = 1, 
                Category = 3, 
                Price = 3400
            };
            var room3 = new Room
            {
                Amount = 2,
                Category = 1,
                Price = 1800
            };

            var room4 = new Room
            {
                Amount = 2,
                Category = 2,
                Price = 2800
            };

            var room5 = new Room
            {
                Amount = 2,
                Category = 3,
                Price = 3800
            };

            var room6 = new Room
            {
                Amount = 1,
                Category = 1,
                Price = 900
            };

            var room7 = new Room
            {
                Amount = 1,
                Category = 2,
                Price = 1600
            };

            var room8 = new Room
            {
                Amount = 3,
                Category = 2,
                Price = 2800
            };

            var room9 = new Room
            {
                Amount = 3,
                Category = 3,
                Price = 4300
            };

            db.Rooms.Add(room1);
            db.Rooms.Add(room2);
            db.Rooms.Add(room3);
            db.Rooms.Add(room4);
            db.Rooms.Add(room5);
            db.Rooms.Add(room6);
            db.Rooms.Add(room7);
            db.Rooms.Add(room8);
            db.Rooms.Add(room9);
            
            //создание сервисов
            var service1 = new Service
            {
                Name ="Детская кровать", Price = 200
            };

            var service2 = new Service
            {
                Name = "Завтрак",
                Price = 250
            };

            db.Services.Add(service1);
            db.Services.Add(service2);

            //коэффициенты по неделям
            var day1 = new Week
            {
                Day = "Понедельник",
                Coefficient = 1
            };

            var day2 = new Week
            {
                Day = "Вторник",
                Coefficient = 1.1
            };

            var day3 = new Week
            {
                Day = "Среда",
                Coefficient = 1.1
            };
            var day4 = new Week
            {
                Day = "Четверг",
                Coefficient = 1.1
            };
            var day5 = new Week
            {
                Day = "Пятница",
                Coefficient = 1.3
            };
            var day6 = new Week
            {
                Day = "Суббота",
                Coefficient = 1.5
            };

            var day7 = new Week
            {
                Day = "Воскресенье",
                Coefficient = 1.5
            };
            db.Weeks.Add(day1);
            db.Weeks.Add(day2);
            db.Weeks.Add(day3);
            db.Weeks.Add(day4);
            db.Weeks.Add(day5);
            db.Weeks.Add(day6);
            db.Weeks.Add(day7);
            var booking1 = new Booking
            {
                CustomerName = "Лионель Месси",  DepartureDate = new DateTime(2016,07,01), ArrivalDate = new DateTime(2016, 06, 25),
                Services = new List<Service>() {service1, service2 }
            };


            room1.Bookings.Add(booking1);

            db.Bookings.Add(booking1);
            base.Seed(db);
        }
    }
}