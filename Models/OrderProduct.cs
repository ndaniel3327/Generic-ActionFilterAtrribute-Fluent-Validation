using System.ComponentModel.DataAnnotations.Schema;

namespace BookzoneProjNituDaniel.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        [ForeignKey(nameof (Product))]
        public int ProductId { get; set; }


        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
