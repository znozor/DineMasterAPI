using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class User
    {
            [Key]
            public int UserId { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } = "Customer";

            [Required]
            public string CreatedBy { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; } = DateTime.Now;

            public string? ModifiedBy { get; set; }

            public DateTime? ModifiedAt { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Reservation> AssignedReservations { get; set; }
        public List<Order> Orders { get; set; }
        public List<StaffShift> StaffShifts { get; set; }
    }
}
