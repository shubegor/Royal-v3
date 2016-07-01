using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class BookingsController : Controller
    {
        //создаем контекст данных
        private readonly HotelContext _db = new HotelContext();
        public ActionResult Index()
        {
            //получаем из БД все объекты
            var bookings = _db.Bookings.Include(b => b.Room);

            //возвращаем представление
            return View(bookings.ToList());
        }

        //просмотр детальной информации
        public ActionResult Details (int? id)
        {
            var booking = _db.Bookings.Include(b => b.Room).FirstOrDefault(b => b.Id == id);
            
            var booking1 = _db.Bookings.Include(r => r.Services).FirstOrDefault(r => r.Id == id);

            if ((booking == null)&(booking1 == null))
            {
                return HttpNotFound();
            }
            return View(booking);

        }

        //для редактирования модели
         [HttpGet]
        public ActionResult Edit(int? id)
        {
             if (id == null)
             {
                 return HttpNotFound();
             }

             var booking = _db.Bookings.Find(id);
             if (booking != null)
             {
                 var rooms = new SelectList(_db.Rooms,"Id", "Id", booking.RoomId);
                 ViewBag.Rooms = rooms;
                 return View(booking);
             }
             return RedirectToAction("Index");
        }
        //сохранение отредактированной модели
    [HttpPost]
        public ActionResult Edit(Booking booking)
         {
             _db.Entry(booking).State = EntityState.Modified;
             _db.SaveChanges();
             return RedirectToAction("Index");
         }
        //Добавление модели
    [HttpGet]
        public ActionResult Create ()
        {
            var rooms = new SelectList(_db.Rooms, "Id", "Id");
            ViewBag.Rooms = rooms;

            var services = new SelectList(_db.Services, "Id", "Name");
            ViewBag.Services = services;

            return View();
        }
        //Сохранение добавленной модели
        [HttpPost]
        public ActionResult Create (Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        //удаление модели
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var book = _db.Bookings.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteCofirm(int? id)
        {
            var booking = _db.Bookings.Find(id);
            _db.Bookings.Remove(booking);
            _db.SaveChanges();

            return RedirectToAction("Action");
        }


    }
}