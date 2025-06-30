using DineMaster.Enum;

namespace DineMaster.DTO
{
    public class ReservationDetailsDTO
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public int GuestCount { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; }

        public int? TableId { get; set; }
        public string? TableName { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public int? AssignedWaiterId { get; set; }
        public string? WaiterName { get; set; }
    }
}
