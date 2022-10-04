using FRUIT_SHOP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FRUIT_SHOP.Helpers
{
    public class CustomDelete: PageModel
    {
       static ApplicationContext db;

    
        public static bool OnPost(int? Id)
        {
            var OldData = db.users.Find(Id);
            if (OldData != null)
            {
                db.users.Remove(OldData);
                db.SaveChanges();
                return true;
               
            }
            else
            {
                return false;
            }
            
        }
    }
}
