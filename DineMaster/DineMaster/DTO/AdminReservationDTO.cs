using DineMaster.Enum;

namespace DineMaster.DTO
{
    public class AdminReservationDTO
    {
        public int ReservationId { get; set; }
        public int? AssignedWaiterId { get; set; }

        // Optional but recommended if admin changes status
        public ReservationStatus Status { get; set; }
    }
}
