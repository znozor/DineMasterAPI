using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        [Required]
        public string UnitName { get; set; }

        public string Description { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
        public List<MenuItemIngredient> Ingredients { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; }
    }
}
