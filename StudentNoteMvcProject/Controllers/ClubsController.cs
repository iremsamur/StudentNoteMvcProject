using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNoteMvcProject.Models.EntityFramework;//model alanlarıma ulaşmam için bunu dahil etmeliyim.
namespace StudentNoteMvcProject.Controllers
{
    public class ClubsController : Controller
    {
        SCHOOLEntities1 school = new SCHOOLEntities1();//Veritabanı adımla aynı Entities nesnesi , Bu veritabanımdaki tablolarıma ulaşmak için 
        //kullanacağım nesnem. Bu entity framework oluşturunca veritababanıadıEntities şeklinde otomatik oluştu.
        //Kulüpleri listelemek içinde bir controller ekledim.
        // GET: Clubs
        public ActionResult Index()//Bu bizim kulüp sayfamızın index'i, Her bir controller için view oluşturmalıyım
                                   //O yüzden bunun içinde Index üzerinde sağa tıklayıp view oluştururum.
        {
            var clubs = school.CLUBS.ToList();
            
            return View(clubs);
        }
        [HttpGet]
        public ActionResult NewClub()
        {
            return View();
            
            

        }
        [HttpPost]
        public ActionResult NewClub(CLUBS club) 
        {
            school.CLUBS.Add(club);
            school.SaveChanges();
            return View();

        }
        public ActionResult DeleteClub(int id)
        {
            var club = school.CLUBS.Find(id);//gönderdiğim id'ye göre tabloda kulüpler içinde silinmek istenen kulübü bulur.
            school.CLUBS.Remove(club);//kulüp değişkeninden gelen değeri kaldırır. Yani siler.
            school.SaveChanges();
            return RedirectToAction("Index");
               
                

        }
        public ActionResult ListClub()
        {
            //kulüplerin listelendiği yerden , güncelle butonuna bastığım kulübü seçince onun id'sinin kulüp güncelleme sayfasının text box'ında da yazmasını istiyorsam burada kodları yazarım.
            return View();
        }
        
    }
}