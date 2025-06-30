using DineMaster.Enum;
using DineMaster.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster.DTO
{
    public class CustomerReservationDTO
    {


        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public int GuestCount { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int? TableId { get; set; }
        public DateTime ReservationDate { get; set; }

        public ReservationStatus Status { get; set; } = ReservationStatus.Confirmed;

        public int UserId { get; set; }


    }
}
