using FRUIT_SHOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRUIT_SHOP.Controllers
{
    public class UserController : Controller
    {
       ApplicationContext _db;
        static int UserId;
        public UserController(ApplicationContext db)
        {
            this._db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Users model)
        {
            if (ModelState.IsValid)
            {
                var data = new Users()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    IsAdmin = false
                };
                await _db.users.AddAsync(data);
                await _db.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            else
            {
                 ModelState.AddModelError("", "Some Field is wrong");
                return View(model);
            }
   
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Users model)
        {
            if (model!=null)
            {
                //check User In Data Base



                Users? x = _db.users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                if (x != null)
                {
                         UserId = x.Id;
                     HttpContext.Session.SetInt32("UserId", x.Id);
                    return RedirectToAction("Profile");
                }

                else
                {

                    ViewBag.clas = "true";
                    ViewBag.error = "Email Or Password Is Not Correct";
                    // ModelState.AddModelError("", "Email Or Password Is Not Correct");

                }

           


            }
                    return View(model);
            
        }
        public IActionResult Profile()
        {
            var UserData =  _db.users.Where(u=>u.Id==UserId).FirstOrDefault();
            return View(UserData);
        }
    }
}
