using DineMaster.Models;

namespace DineMaster.Repository
{
    public interface IMenuItemRepo
    {

        IEnumerable<MenuItem> GetAll();
        MenuItem Get(int id);
        void Add(MenuItem menuItem);
        void Update(MenuItem menuItem);
        void Delete(int id);


    }
}
