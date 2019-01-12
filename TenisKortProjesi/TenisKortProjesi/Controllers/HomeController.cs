using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenisKortProjesi.Models;
namespace TenisKortProjesi.Controllers
{

    public class HomeController : Controller
    {
        public static ViewModel mymodel = new ViewModel();

        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult BillsQuery(string txPhone)
        {
            try
            {
                using (TenisKortuUygulamaEntities entities = new TenisKortuUygulamaEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var users = entities.Users.FirstOrDefault(x => x.Phone == txPhone);
                    var rezervation = entities.Rezervation.Include("Bills").Where(x => x.UsersId == users.id && x.IsComplated == false).ToList();
                    ViewBag.Bills = rezervation;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public void FillTable()
        {
            //ekrana bir adet tablo basılacak ve bu tabloda dolu olan günler ve saaatler gözükecek
            using (
                TenisKortuUygulamaEntities Entities = new TenisKortuUygulamaEntities())
            {

                Entities.Configuration.LazyLoadingEnabled = false;


                var Rezervations = Entities.Rezervation.Include("Hours").Where(x => x.IsComplated == false).OrderBy(s => s.Date).ToList();
                ViewBag.rezervation = Rezervations;

            }
        }
        public ActionResult Rezervation()
        {
            FillTable();

            using (TenisKortuUygulamaEntities Entities = new TenisKortuUygulamaEntities())
            {



                if (Convert.ToBoolean(Session["isLogin"]) == true)
                {

                    int id = Convert.ToInt32(Session["id"].ToString());
                    var check = Entities.Users.FirstOrDefault(x => x.id == id);

                    mymodel.users = Entities.Users.FirstOrDefault(x => x.id == id);
                    mymodel.hours = Entities.Hours.ToList();
                    mymodel.fields = Entities.Fields.ToList();
                    return View(mymodel);
                    //asdaaa
                }
                else
                {

                    mymodel.hours = Entities.Hours.ToList();
                    mymodel.fields = Entities.Fields.ToList();
                    return View(mymodel);
                }
            }
        }
        [HttpPost]
        public JsonResult Rezervation(string Name, string Surname, string Phone, string Date, int Hour, int Field)
        {


            //mevcut tarih saatde rezervasyon varmı kontrol et!
            //yoksa rezervasyon basarılı
            //varsa sıraya al

            using (TenisKortuUygulamaEntities Entities = new TenisKortuUygulamaEntities())
            {
                try
                {

                    FillTable();
                    Rezervation rezervation = new Rezervation();
                    Users users = new Users();
                    DateTime date = new DateTime();
                    date = Convert.ToDateTime(Date);
                    Convert.ToDateTime(Date);
                    var IsRezervationAvaible = Entities.Rezervation.FirstOrDefault(x => x.HoursId == Hour && x.Date == date);
                    if (IsRezervationAvaible != null)
                    {
                        TempData["msg"] = "<script>document.getElementById('BtnQueue').style.visibility = 'visible';document.getElementById('isFinish').innerHTML = 'Seçmeye çalıştığınız tarih ve saat doludur!'; </script>";

                        return Json(new { Status = "Warning", Message = "İlgili tarih ve kort uygun değildir lütfen başka bir seçim yapınız yada sıraya giriniz!" }, JsonRequestBehavior.AllowGet);
                    }

                    var check = Entities.Users.FirstOrDefault(x => x.Phone == Phone);
                    if (check == null) //Daha önce hiç rezervasyon yaptırmamışsa
                    {
                        users.Name = Name;
                        users.Surname = Surname;   //Users tablosuna kayıt kısmı
                        users.Phone = Phone;
                        users.isMember = false;
                        Entities.Users.Add(users); //Şimdilik veri tabanına  kayıt yaptırmadım
                        Entities.SaveChanges();
                        rezervation.HoursId = Hour;
                        rezervation.UsersId = users.id; //Rezervasyon tablosuna kayıt kısmı
                        rezervation.FieldsId = Field;
                        rezervation.Date = Convert.ToDateTime(Date);
                        rezervation.IsComplated = false;
                        Entities.Rezervation.Add(rezervation);
                        Entities.SaveChanges();
                        TempData["msg"] = "<script>document.getElementById('isFinish').innerHTML='Kaydiniz basarilidir.';</script>";
                    }
                    else
                    {
                        rezervation.HoursId = Hour;
                        rezervation.UsersId = check.id; //Rezervasyon tablosuna kayıt kısmı
                        rezervation.FieldsId = Field;
                        rezervation.Date = Convert.ToDateTime(Date);
                        rezervation.IsComplated = false;
                        Entities.Rezervation.Add(rezervation);
                        Entities.SaveChanges();
                        TempData["msg"] = "<script>document.getElementById('isFinish').innerHTML='Kaydiniz basarilidir.';</script>";
                    }

                    return Json(new { Status = "OK", Message = "İşlem Başarılı!" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { Status = "Error", Message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }

        }

        [HttpGet]
        public JsonResult AjaxQueue(string Phone, string Hour, string Field, string Date, string Name, string Surname)
        {
            try
            {


                using (TenisKortuUygulamaEntities Entities = new TenisKortuUygulamaEntities())
                {
                    Queue queue = new Queue();
                    DateTime date = new DateTime();
                    date = Convert.ToDateTime(Date);
                    Users users = new Users();
                    var check = Entities.Users.FirstOrDefault(x => x.Phone == Phone);
                    if (check == null) //Daha önce hiç rezervasyon yaptırmamışsa
                    {
                        users.Name = Name;
                        users.Surname = Surname;   //Users tablosuna kayıt kısmı
                        users.Phone = Phone;
                        users.isMember = false;
                        Entities.Users.Add(users);
                        Entities.SaveChanges();
                        queue.HoursId = Convert.ToInt32(Hour);
                        queue.UsersId = users.id;
                        queue.FieldsId = Convert.ToInt32(Field);
                        queue.QueueDate = date;
                        queue.IsComplated = false;
                        Entities.Queue.Add(queue);
                        Entities.SaveChanges();

                        TempData["msg"] = "<script>document.getElementById('isFinish').innerHTML='Sıraya girdiniz.';</script>";
                    }
                    else
                    {
                        queue.HoursId = Convert.ToInt32(Hour); ;
                        queue.UsersId = check.id;
                        queue.FieldsId = Convert.ToInt32(Field);
                        queue.QueueDate = date;
                        queue.IsComplated = false;
                        Entities.Queue.Add(queue);
                        Entities.SaveChanges();
                        TempData["msg"] = "<script>document.getElementById('isFinish').innerHTML='Sıraya girdiniz.';</script>";
                    }
                    return Json(new { Status = "OK", Message = "İşlem Başarılı!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Status = "Error", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        [HttpGet]
        public ActionResult Bills()
        {
            using (TenisKortuUygulamaEntities Entities = new TenisKortuUygulamaEntities())
            {

                Entities.Configuration.LazyLoadingEnabled = false;
               

                var Bills = Entities.Bills.Include("Hours").Include("Rezervation1").Include("Fields").Where(x => x.isPaid == false).ToList();
                foreach(var item in Bills)
                {
                    BillModel bm = new BillModel();
                    bm.Date = Convert.ToDateTime( item.Rezervation1.Date);
                    bm.Amounth = item.Amount;
                    bm.FieldId = item.Rezervation1.FieldsId;
                    bm.Hour = item.Rezervation1.Hours.Hour;
                    bm.Id = item.Rezervation1.id;
                    mymodel.BillLister.Add(bm);
                }
                

                ViewBag.Bills = Bills;
                return View(mymodel);
            }
        }

    }
}