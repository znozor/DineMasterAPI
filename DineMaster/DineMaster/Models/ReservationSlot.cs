using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class ReservationSlot
    {
        [Key]
        public int SlotId { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
