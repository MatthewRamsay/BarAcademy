using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using ILikeTheBartender.Models;

namespace ILikeTheBartender.Controllers
{
    public class DrinkOrdersController : Controller
    {
        private ILikeTheBartenderContext db = new ILikeTheBartenderContext();

        // GET: DrinkOrders
        public ActionResult Index()
        {
            var openDrinks = db.DrinkOrders.Where(d => d.Completed == false);
            return View(openDrinks.ToList());
        }


        public ActionResult ShowCompletedDrinks()
        {
            var closedDrinks = db.DrinkOrders.Where(d => d.Completed == true);
            return View(closedDrinks.ToList());
        }
     

        // GET: DrinkOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrinkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,Completed,CustomerName,Alcohol,Mixer")] DrinkOrder drinkOrder)
        {
            if (ModelState.IsValid)
            {
                db.DrinkOrders.Add(drinkOrder);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(drinkOrder);
        }

        // GET: DrinkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkOrder drinkOrder = db.DrinkOrders.Find(id);
            if (drinkOrder == null)
            {
                return HttpNotFound();
            }
            return View(drinkOrder);
        }


        // POST: DrinkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,Completed,CustomerName,Alcohol,Mixer")] DrinkOrder drinkOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drinkOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drinkOrder);
        }


        // GET: DrinkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkOrder drinkOrder = db.DrinkOrders.Find(id);
            if (drinkOrder == null)
            {
                return HttpNotFound();
            }
            return View(drinkOrder);
        }


        // POST: DrinkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrinkOrder drinkOrder = db.DrinkOrders.Find(id);
            db.DrinkOrders.Remove(drinkOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
