using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenisKortProjesi.Models;
namespace TenisKortProjesi.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Login()
        {

            if (Convert.ToBoolean(Session["isLogin"]) == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost] //post post
        public ActionResult Login(string Name, string Password)
        {


            using (TenisKortuUygulamaEntities Entities = new TenisKortuUygulamaEntities())
            {
                var Check = Entities.Users.FirstOrDefault(x => x.Name == Name && x.Password == Password && x.isMember == true);
                if (Check != null)
                {

                    Session["isLogin"] = true;
                    Session["Name"] = Check.Name.ToString();
                    Session["Password"] = Check.Password.ToString();
                    Session["id"] = Check.id.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["isLogin"] = false;
                    Session["Error"] = "Kullanici adi veya şifresi hatalı";
                    TempData["loginError"] = "<script>document.getElementById('isFinish').innerHTML='Kullanici adi veya sifreniz yanlis.';</script>";
                }
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        // GET: Users
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users Users)
        {
            if (ModelState.IsValid)
            {
                using (TenisKortuUygulamaEntities Entities = new TenisKortuUygulamaEntities())
                {
                    var Check = Entities.Users.FirstOrDefault(x => x.Password == Users.Password || x.Phone == Users.Phone);
                    if (Check != null && Check.isMember == true)
                    {
                        ModelState.Clear();
                        ViewBag.message = "Böyle bir kayıt bulunmaktadır.";
                    }
                    else if (Check != null && Check.isMember == false && Check.Password == null)
                    {
                        Check.isMember = true;
                        Check.Name = Users.Name;
                        Check.Surname = Users.Surname;
                        Check.Password = Users.Password;
                        Entities.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Users.isMember = true;
                        Entities.Users.Add(Users);
                        Entities.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            return View();
        }
        public ActionResult GetProfile(int id)
        {
            if (Convert.ToBoolean(Session["isLogin"]) == true)
            {
                TenisKortuUygulamaEntities Entities = new TenisKortuUygulamaEntities();
                var query = from rezervation in Entities.Rezervation
                            join users in Entities.Users on rezervation.UsersId equals id
                            join hours in Entities.Hours on rezervation.HoursId equals hours.id
                            where users.id == id
                            select new UsersProfile
                            {
                                UsersId = users.id,
                                Name = users.Name,
                                Surname = users.Surname,
                                Phone = users.Phone,
                                FieldsId = rezervation.FieldsId,
                                Hour = hours.Hour
                            };
                return View(query);
            }

            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
    }
}