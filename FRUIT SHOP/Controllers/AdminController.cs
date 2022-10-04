using FRUIT_SHOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRUIT_SHOP.Controllers
{
    public class AdminController : Controller
    {
        static int UserId;
        ApplicationContext db;

        public AdminController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult OurFruit()
        {
            return View();
        }
        public IActionResult TestMilons()
        {
            return View();
        }     
        public IActionResult ContactUs()
        {
            return View();
        }  
        public IActionResult Users()
        {
            return View();
        }
    }
}
