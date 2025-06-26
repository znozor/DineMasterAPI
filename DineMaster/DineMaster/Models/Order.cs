using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderType { get; set; } // Dinein, TakeAway, Online

        public int? TableId { get; set; }
        public Table Table { get; set; }

        [ForeignKey("OrderedByUser")]
        public int OrderedBy { get; set; }
        public User OrderedByUser { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        
    }
}
