using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineMaster.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        
        public Supplier Supplier { get; set; }

        public DateTime PurchaseDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string Notes { get; set; }

        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
