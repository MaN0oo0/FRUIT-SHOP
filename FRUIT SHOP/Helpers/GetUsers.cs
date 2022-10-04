using FRUIT_SHOP.Models;

namespace FRUIT_SHOP.Helpers
{
    public  class GetUsers
    {
        private static ApplicationContext db;

        public static ApplicationContext Db { get => db; set => db = value; }

        public static Users GetUserss(int Id)
        {
            var data = Db.users.Where(m=>m.Id==Id).FirstOrDefault();
            return data;
        }
    }
}
