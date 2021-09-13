using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNoteMvcProject.Models.EntityFramework;//model alanlarıma ulaşmam için bunu dahil etmeliyim.

namespace StudentNoteMvcProject.Controllers
{
    public class ExamsController : Controller
    {
        SCHOOLEntities1 school = new SCHOOLEntities1();
        //1-Her Sınıf için dersler,öğrenciler vvb. önce controller oluşturulur. Çünkü her sınıfın kendi controller'ı içine listeleme,ekleme silme vb. veritabanı işlemleri yazılır
        //2- Sonra her controller'ın metoduna Index metodu sağ tıklayarak bir tane view eklenir. Çünkü bu view her sınıfın içeriğinin görüneceği kendi içerik alanıdır.
        //3- Bu view'e içerik kodları yazılır. Yani veritabanından verilerin getirildiği,eklendiği işlemlerle ve tablo oluşturma gibi html css kodları
        //Bu aşamalar uygulanır.
        // GET: Exams
        public ActionResult Index()
        {
            var notes = school.NOTES.ToList();

            return View(notes);//Veritabanından çektiği verileri döndürür. Ve bu controlle^r'ın bağlı olduğu view'e taşır. Yani Exams için Exams klasörü içinde oluşturduğum Index.cshtml view'ine taşır.
        }
        [HttpGet]
        public ActionResult newExam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newExam(NOTES note)
        {
            school.NOTES.Add(note);
            school.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}