using FRUIT_SHOP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FRUIT_SHOP.Controllers
{
    public class AdminController : Controller
    {
        static int? UserId;
      
        ApplicationContext db;
        dynamic adminUser;


        public AdminController(ApplicationContext db)
        {
            this.db = db;
          adminUser = db.users.Where(x => x.IsAdmin == true).Select(m => m.Id).FirstOrDefault();
        }


   
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId").GetValueOrDefault() == adminUser)
            {


                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult OurFruit()
        {
            UserId = HttpContext.Session.GetInt32("UserId");
            if (HttpContext.Session.GetInt32("UserId") != null)
            {


                var data = db.ourFruits.ToList();
                return View(data);

            }
            else
            {
                return RedirectToAction("Login", "User");
            }


        }
 
        public IActionResult CreateOurFruit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateOurFruit(OurFruit model)
        {
            if (ModelState.IsValid)
            {
                var data = new OurFruit()
                {
                    Id = model.Id,
                    Titel = model.Titel,
                    Descreption = model.Descreption,
                    Price = model.Price
                };
            db.ourFruits.Add(data);
                db.SaveChanges();
                return RedirectToAction("OurFruit");

            }
            return View(model);
        }
        public IActionResult TestMilons()
        {
            UserId = HttpContext.Session.GetInt32("UserId");
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                Users? data = db.users.Where(u => u.Id == UserId).FirstOrDefault();

                ViewBag.user = new Users { Id = data.Id, Name = data.Name, Email = data.Email, PhoneNumber = data.PhoneNumber };

                return View();

            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
     
        public IActionResult ContactUs()
        {
            UserId= HttpContext.Session.GetInt32("UserId");
            if (HttpContext.Session.GetInt32("UserId")!=null)
            {
                Users? data=db.users.Where(u => u.Id==UserId).FirstOrDefault();

                ViewBag.user = new Users{Id=data.Id,Name=data.Name,Email=data.Email,PhoneNumber=data.PhoneNumber}; 

            return View();

            }
            else
            {
                return RedirectToAction("Login","User");
            }
        }
        [HttpPost]
        public IActionResult ContactUs(ContactUs model)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                int x = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
                if (model != null)
                {
                    var data = new ContactUs
                    {
                        Message = model.Message,
                        UserId = x

                    };
                    db.contactUs.Add(data);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }


        public IActionResult ListOfContactUs()
        {
            if (HttpContext.Session.GetInt32("UserId").GetValueOrDefault() == adminUser)
            {
                var data = db.contactUs.Include(m => m.user).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
         
        }


    }
}
