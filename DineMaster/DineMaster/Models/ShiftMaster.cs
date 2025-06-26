using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class ShiftMaster
    {
        [Key]
        public int ShiftId { get; set; }

        public string ShiftName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public List<StaffShift> StaffShifts { get; set; }
    }
}
