using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TenisKortProjesi.Models;

namespace TenisKortProjesi.Controllers
{
    public class RezervationsAdminController : Controller
    {
        private TenisKortuUygulamaEntities db = new TenisKortuUygulamaEntities();

        // GET: RezervationsAdmin
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                var rezervation = db.Rezervation.Include(r => r.Fields).Include(r => r.Hours).Include(r => r.Users);
                return View(rezervation.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: RezervationsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Rezervation rezervation = db.Rezervation.Find(id);
                if (rezervation == null)
                {
                    return HttpNotFound();
                }
                return View(rezervation);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: RezervationsAdmin/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                ViewBag.FieldsId = new SelectList(db.Fields, "id", "id");
                ViewBag.HoursId = new SelectList(db.Hours, "id", "Hour");
                ViewBag.UsersId = new SelectList(db.Users, "id", "Name");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: RezervationsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UsersId,FieldsId,Date,HoursId,IsComplated")] Rezervation rezervation)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (ModelState.IsValid)
                {
                    db.Rezervation.Add(rezervation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.FieldsId = new SelectList(db.Fields, "id", "id", rezervation.FieldsId);
                ViewBag.HoursId = new SelectList(db.Hours, "id", "Hour", rezervation.HoursId);
                ViewBag.UsersId = new SelectList(db.Users, "id", "Name", rezervation.UsersId);
                return View(rezervation);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: RezervationsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Rezervation rezervation = db.Rezervation.Find(id);
                if (rezervation == null)
                {
                    return HttpNotFound();
                }
                ViewBag.FieldsId = new SelectList(db.Fields, "id", "id", rezervation.FieldsId);
                ViewBag.HoursId = new SelectList(db.Hours, "id", "Hour", rezervation.HoursId);
                ViewBag.UsersId = new SelectList(db.Users, "id", "Name", rezervation.UsersId);
                return View(rezervation);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: RezervationsAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UsersId,FieldsId,Date,HoursId,IsComplated")] Rezervation rezervation)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (ModelState.IsValid)
                {
                    db.Entry(rezervation).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.FieldsId = new SelectList(db.Fields, "id", "id", rezervation.FieldsId);
                ViewBag.HoursId = new SelectList(db.Hours, "id", "Hour", rezervation.HoursId);
                ViewBag.UsersId = new SelectList(db.Users, "id", "Name", rezervation.UsersId);
                return View(rezervation);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: RezervationsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Rezervation rezervation = db.Rezervation.Find(id);
                if (rezervation == null)
                {
                    return HttpNotFound();
                }
                return View(rezervation);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: RezervationsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                Rezervation rezervation = db.Rezervation.Find(id);
                db.Rezervation.Remove(rezervation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
