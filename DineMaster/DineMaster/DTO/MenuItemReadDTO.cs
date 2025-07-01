using DineMaster.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineMaster.DTO
{
    public class MenuItemReadDTO
    {
        public int ItemId { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        //public string? CategoryName { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public string? ImageUrl { get; set; }
    }
}
