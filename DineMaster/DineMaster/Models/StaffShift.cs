using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class StaffShift
    {
        [Key]
        public int StaffShiftId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("ShiftMaster")]
        public int ShiftMasterId { get; set; }
        public ShiftMaster ShiftMaster { get; set; }

        public DateTime LoginTime { get; set; }=DateTime.Now;
        public DateTime LogoutTime { get; set; }

        //[NotMapped]
        //public int ShiftDuration => (int)(LogoutTime - LoginTime).TotalMinutes;
    }
}
