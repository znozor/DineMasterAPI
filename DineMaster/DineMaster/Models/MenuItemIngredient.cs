using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class MenuItemIngredient
    {
        [Key]
        public int MenuItemIngredientId { get; set; }

        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }

        [ForeignKey("InventoryItem")]
        public int InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public int QuantityRequired { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
