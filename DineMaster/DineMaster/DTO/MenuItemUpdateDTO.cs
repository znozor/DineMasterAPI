﻿namespace DineMaster.DTO
{
    public class MenuItemUpdateDTO
    {
        public int ItemId { get; set; }             
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public string? ImageUrl { get; set; }
    }
}
