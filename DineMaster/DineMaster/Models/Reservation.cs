using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DineMaster.Enum;

namespace DineMaster.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        public string CustomerName { get; set; }

        public string Contact { get; set; }

        public int GuestCount { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }



        [ForeignKey("Table")]
        public int? TableId { get; set; }
        public Table Table { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }



        public ReservationStatus Status { get; set; } = ReservationStatus.Confirmed;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("AssignedWaiter")]
        public int? AssignedWaiterId { get; set; }
        public User AssignedWaiter { get; set; }
    }
}
