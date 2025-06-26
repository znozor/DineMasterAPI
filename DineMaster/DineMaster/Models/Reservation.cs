using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        public string CustomerName { get; set; }

        public string Contact { get; set; }

        [ForeignKey("Table")]
        public int? TableId { get; set; }
        public Table Table { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [ForeignKey("ReservationSlot")]
        public int SlotId { get; set; }
        public ReservationSlot ReservationSlot { get; set; }

        public string Status { get; set; } // Confirmed, Cancelled, Completed

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("AssignedWaiter")]
        public int AssignedWaiterId { get; set; }
        public User AssignedWaiter { get; set; }
    }
}
