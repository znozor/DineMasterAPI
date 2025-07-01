using AutoMapper;
using DineMaster.Data;
using DineMaster.Models;
using DineMaster.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DineMaster.Service
{
    public class MenuCategoryServices : IMenuCategoryRepo
    {
        private readonly DineMasterDbContext db;

        public MenuCategoryServices(DineMasterDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<MenuCategory> GetAll()
        {
            var data = db.MenuCategories.ToList();
            return data;
        }

        public MenuCategory GetById(int id)
        {
            var data = db.MenuCategories.Find(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public void Add(MenuCategory category)
        {
            db.MenuCategories.Add(category);
            db.SaveChanges();
        }

        public void Update(MenuCategory category)
        {
            db.MenuCategories.Update(category);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var data = db.MenuCategories.Find(id);

            if (data != null)
            {
                db.MenuCategories.Remove(data);
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var data = db.MenuCategories.Find(id);

            if (data != null)
            {
                db.MenuCategories.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
