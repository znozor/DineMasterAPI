using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public MenuCategory Category { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public string ImageUrl { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<MenuItemIngredient> Ingredients { get; set; }
    }
}
