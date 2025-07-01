using DineMaster.Models;

namespace DineMaster.Repository
{
    public interface IMenuCategoryRepo
    {
        IEnumerable<MenuCategory> GetAll();
        MenuCategory GetById(int id);
        void Add (MenuCategory category);
        void Update(MenuCategory category);
        void Delete(int id);

    }
}
