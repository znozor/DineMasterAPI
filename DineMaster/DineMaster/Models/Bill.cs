using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineMaster.Models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public DateTime BillDate { get; set; }= DateTime.Now;
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
        public double TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
