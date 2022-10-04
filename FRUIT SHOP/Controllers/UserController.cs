using FRUIT_SHOP.Helpers;
using FRUIT_SHOP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FRUIT_SHOP.Controllers
{
    public class UserController : Controller
    {
        ApplicationContext _db;
        static int? UserId;
        public UserController(ApplicationContext db)
        {
            this._db = db;
        }

        static int adminUser;
        public async Task<IActionResult> Index()
        {
            UserId = HttpContext.Session.GetInt32("UserId");
            adminUser = _db.users.Where(x => x.IsAdmin == true).Select(m => m.Id).FirstOrDefault();
            if (UserId==null)
            {
                return RedirectToAction("Login");
            }
            else {

                if (HttpContext.Session.GetInt32("UserId") == adminUser)
                {

                    var data = await _db.users.ToListAsync();
                    return View(data);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }

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
            if (model != null)
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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Profile()
        {
            var UserData = _db.users.Where(u => u.Id == UserId).FirstOrDefault();
            return View(UserData);
        }

        #region Delete Hander Action



        //public IActionResult Delete(int? Id)
        //{
        //    if (CustomDelete.OnPost(Id))
        //    {
        //        return RedirectToAction("index");

        //    }
        //    else
        //    {
        //        return RedirectToAction("index");
        //    }



        //}


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _db.users.FindAsync(id);
            _db.users.Remove(user);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateConfirm(Users model)
        {
            if (model.Id == null)
            {
                return NotFound();

            }
            else
            {
                var user = await _db.users.FirstOrDefaultAsync(m => m.Id == model.Id);
                user.Id = model.Id;
                user.Name = model.Name;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                await _db.SaveChangesAsync();
                if (model.IsAdmin==true)
                {

                return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Profile));
                }
            }
           
        }
        #endregion


        
    }

}
