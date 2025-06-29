using System.ComponentModel.DataAnnotations;

namespace DineMaster.DTO
{
    public class TableDTO
    {
        public int TableId { get; set; }

        public string TableName { get; set; }

        public int Capacity { get; set; }

        public string Status { get; set; } = "Available";


        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }

    }
}
