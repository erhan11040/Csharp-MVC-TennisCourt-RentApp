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
    public class UsersAdminController : Controller
    {
        private TenisKortuUygulamaEntities db = new TenisKortuUygulamaEntities();

        // GET: UsersAdmin
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                return View(db.Users.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UsersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Users users = db.Users.Find(id);
                if (users == null)
                {
                    return HttpNotFound();
                }

                return View(users);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UsersAdmin/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: UsersAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Surname,Phone,isMember,Password")] Users users)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(users);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(users);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UsersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Users users = db.Users.Find(id);
                if (users == null)
                {
                    return HttpNotFound();
                }
                return View(users);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: UsersAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Surname,Phone,isMember,Password")] Users users)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (ModelState.IsValid)
                {
                    db.Entry(users).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(users);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: UsersAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Users users = db.Users.Find(id);
                if (users == null)
                {
                    return HttpNotFound();
                }
                return View(users);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: UsersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Convert.ToString(Session["Name"]) == "baran" && Convert.ToString(Session["Password"]) == "123456")
            {
                Rezervation rezervation = new Rezervation();
                var removerezervation = db.Rezervation.Where(x => x.UsersId == id).ToList();
                foreach (var item in removerezervation)    //Kullanıcıların silinmesi için yaptırdığı rezervasyonlarında silinmesi gerekiyor.
                {                                         //Bu yüzden rezervasyonlarıda sildim.      
                    db.Rezervation.Remove(item);
                    db.SaveChanges();
                }
                Users users = db.Users.Find(id);
                db.Users.Remove(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
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
