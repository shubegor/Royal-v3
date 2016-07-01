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
    public class RoomsController : Controller
    {
        private readonly HotelContext _db = new HotelContext();
        public ActionResult Index()
        {
            //возвращаем представление
            return View(_db.Rooms.ToList());
        }
        //просмотр детальной информации
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var room = _db.Rooms.Include(r => r.Bookings).FirstOrDefault(r => r.Id == id);
            
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }
        //для редактирования модели
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var room = _db.Rooms.Find(id);
            if (room != null)
            {

                return View(room);
            }
            return RedirectToAction("Index");
        }
        //сохранение отредактированного значения
        [HttpPost]
        public ActionResult Edit(Room room)
        {
            _db.Entry(room).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}