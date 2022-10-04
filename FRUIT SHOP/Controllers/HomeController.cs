using FRUIT_SHOP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FRUIT_SHOP.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;

        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Users = db.users.ToList();
            return View();
        }

     
    }
}