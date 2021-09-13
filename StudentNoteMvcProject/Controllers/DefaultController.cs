using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNoteMvcProject.Models.EntityFramework;//model alanlarıma ulaşmam için bunu dahil etmeliyim.

namespace StudentNoteMvcProject.Controllers
{
    public class DefaultController : Controller
    {
        SCHOOLEntities1 school = new SCHOOLEntities1();//Veritabanı adımla aynı Entities nesnesi , Bu veritabanımdaki tablolarıma ulaşmak için 
        //kullanacağım nesnem.
        
        // GET: Default
        public ActionResult Index()
        {
            var lessons = school.LESSONS.ToList();//Bu bana veritabanımdan gelen LESSONS tablosundaki verileri listeler .

            return View(lessons);//Bu gelecek olan ders değerlerini döndürsün dedim.Burada veritabanı kodlarını yazarım.
            //Şimdi Index.cshtml'e gidip Burası içerik sayfasıdırın yerine bunu listeleyeceğim tablo oluşturacağım.
        }
        //Yeni ders eklemek için bu kez ekleme için metod yazıyorum. Her işlemin kendi metodu burada controller içinde yazılır.
        
        [HttpGet]
        public ActionResult NewLessonsAdd()
        {
            return View();
        }
        /*Ders ekleme için ekleme metodunu iki kere yazdım. Birisi HttpGet diğer Httppost kullanarak yazdım. Bunları kullanmazsam 
             her eklemede bir tane de null değer ekleme yapar. Aynı zamanda güvenli olmaz. Çünkü arama yerinde url'de gönderdiğim değerler direk görünür.*/


        [HttpPost]
        public ActionResult NewLessonAdd(LESSONS lesson)//metodun tipi ActionResult olur. Her zaman
        {
            school.LESSONS.Add(lesson);//Metod nesne yönelimli programlama için entity framework'den oluşan LESSONS classından lesson isimli bir nesne parametresi aldı.
            //bu parametreyi add metodu ile veritabanına eklenmesi sağlanır.
            school.SaveChanges();//Ekleme,silme,güncelleme gibi veritabanı işlemlerinde değişikliklerin kaydedilmesini sağlar.
            return View();//şimdi listelemede yaptığımız aynı işlemi burada da yaparız. Bu view için bir tane view eklemeliyiz.

        }
        public ActionResult DeleteLesson(int id)
        {
            var lesson = school.LESSONS.Find(id);
            school.LESSONS.Remove(lesson);
            school.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}