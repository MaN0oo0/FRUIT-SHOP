
using Microsoft.EntityFrameworkCore;

namespace FRUIT_SHOP.Models
{
    public class ApplicationContext:DbContext
    {



        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
     public DbSet<TestMonial> testMonials { get; set; }
    public DbSet<OurFruit> ourFruits { get; set; }
    public DbSet<Users> users { get; set; }
    public DbSet<ContactUs> contactUs { get; set; }
    public DbSet<BuyingCarts> buyingCarts { get; set; }

    }
}
