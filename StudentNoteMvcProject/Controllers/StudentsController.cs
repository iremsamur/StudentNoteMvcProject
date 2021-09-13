using StudentNoteMvcProject.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentNoteMvcProject.Controllers
{
    public class StudentsController : Controller
    {
        SCHOOLEntities1 school = new SCHOOLEntities1();//Diğer classlardaki gibi aynı işlemleri yapıyorum
        // GET: Students
        public ActionResult Index()
        {
            var students = school.STUDENTS.ToList();//Verileri getirmek için ToList() kullanılır. Entity framework'de.

            return View(students);

        }
        [HttpGet]
        public ActionResult newStudent()
        {
            /*Önce veritabanındaki verileri listelerim. Bu yüzden veri çekeceğim.*/
            List<SelectListItem> values = (from club in school.CLUBS.ToList()/*LINQ sorgusu kullanarak veritabanındaki kulüpler tablosundaki verileri çekiyorum.*/
                                           select new SelectListItem
                                           {
                                               Text = club.CLUBNAME,//name değeri
                                               Value = club.CLUBID.ToString()//ID değeri
                                           }
                                         ).ToList();
            ViewBag.value = values;//Controller tarafında bu yazdığım veritabanı işlemlerini yani verileri view tarafına taşımk için ViewBag.value kullanacağım.

            //HTTPGet result'ı  içinde kulüpler için veri çekme yaptım. Veri ekleme içinse HTTPpost içinde gerekli kodları yazarım.
           

            /*
             * Üçüncü dropwdownlist kullanımı
             List<SelectListItem> items = new List<SelectListItem>();

     items.Add(new SelectListItem { Text = "Matematik", Value = "0"});

     items.Add(new SelectListItem { Text = "Türkçe", Value = "1" });

     items.Add(new SelectListItem { Text = "Fizik", Value = "2", Selected = true });

     items.Add(new SelectListItem { Text = "Kimya", Value = "3" });

     ViewBag.MovieType = items;

     return View();*/
            return View();

        }
        [HttpPost]
        public ActionResult newStudent(STUDENTS student)
        {
            //HTTPGet result'ı  içinde kulüpler için veri çekme yaptım. Veri ekleme içinse HTTPpost içinde gerekli kodları yazarım.
            var club = school.CLUBS.Where(m => m.CLUBID == student.CLUBS.CLUBID).FirstOrDefault();//Kullanıcının dropdownlistten seçtiği kulübü al demektir. Ve o seçtiği kulübün id değeri ile veritabanında id si aynı olan kulübü o öğrencisye eklemeyi sağlar. Yani id'leri aynı olanın ilk çıkan değerini al demektir.
            student.CLUBS = club;//yeni kulübü ekler.
            school.STUDENTS.Add(student);//Diğer girilen öğrenci bilgilerini ekler.
            school.SaveChanges();
            return RedirectToAction("Index");//Ekleme yaptıktan sonra bizi öğrenci listesini görebilmemiz için index'e yönlendirsin dedik.
            //RedirectToAction yönlendirme yapar.
        }
        public ActionResult StudentDelete(int id)
        {
            var student = school.STUDENTS.Find(id);
            school.STUDENTS.Remove(student);
            school.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}