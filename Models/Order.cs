using System.ComponentModel.DataAnnotations.Schema;

namespace BookzoneProjNituDaniel.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; } = null!;
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
