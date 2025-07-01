using DineMaster.Data;
using DineMaster.Models;
using DineMaster.Repository;
using Microsoft.EntityFrameworkCore;

namespace DineMaster.Service
{
    public class MenuItemServices : IMenuItemRepo
    {
        private readonly DineMasterDbContext db;
        public MenuItemServices(DineMasterDbContext db)
        {
            this.db = db;
        }
        void IMenuItemRepo.Add(MenuItem menuItem)
        {
            db.MenuItems.Add(menuItem);
            db.SaveChanges();
        }

        void IMenuItemRepo.Delete(int id)
        {
            var Item = db.MenuItems.Find(id);
            db.MenuItems.Remove(Item);
            db.SaveChanges();
        }

        MenuItem IMenuItemRepo.Get(int id)
        {
            var item = db.MenuItems.Include(x=>x.Category).
                       FirstOrDefault(x=>x.ItemId==id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

        IEnumerable<MenuItem> IMenuItemRepo.GetAll()
        {
            var data = db.MenuItems.Include(x=>x.Category).ToList();
            return data;
        }

        void IMenuItemRepo.Update(MenuItem menuItem)
        {
            var Item = db.MenuItems.Find(menuItem.ItemId);   
            if (Item != null)
            {
                db.MenuItems.Update(menuItem);
                db.SaveChanges();
            }
        }
    }
}
