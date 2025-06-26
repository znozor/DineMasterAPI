using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineMaster.Models
{
    public class PurchaseItem
    {
        [Key]
        public int PurchaseItemId { get; set; }
        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        [ForeignKey("InventoryItem")]
        public int InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public int Quantity { get; set; }
        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public int UnitPrice { get; set; }
    }
}
