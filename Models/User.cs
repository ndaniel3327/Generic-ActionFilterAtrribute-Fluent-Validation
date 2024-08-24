﻿namespace BookzoneProjNituDaniel.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
