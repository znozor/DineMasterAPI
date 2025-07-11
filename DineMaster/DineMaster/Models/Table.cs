﻿using System.ComponentModel.DataAnnotations;

namespace DineMaster.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        [Required]
        public string TableName { get; set; }

        [Required]
        public int Capacity { get; set; }

        public string Status { get; set; } = "Available";

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }

        public List<Reservation> Reservations { get; set; }
        public List<Order> Orders { get; set; }
    }
}
