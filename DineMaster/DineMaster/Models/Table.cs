using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        [Required]
        public string TableName { get; set; }

        [Required]
        public int Capacity { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Order> Orders { get; set; }
    }
}
