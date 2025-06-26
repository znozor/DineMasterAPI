using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class InventoryItem
    {
        [Key]
        public int InventoryItemId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public DateTime LastUpdated { get; set; }

        public string UpdatedBy { get; set; }
        public List<MenuItemIngredient> MenuItems { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; }
    }
}
