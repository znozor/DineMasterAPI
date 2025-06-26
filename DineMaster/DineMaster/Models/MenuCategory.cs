using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class MenuCategory
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryType { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
