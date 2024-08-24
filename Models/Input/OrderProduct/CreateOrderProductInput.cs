using System.ComponentModel.DataAnnotations.Schema;

namespace BookzoneProjNituDaniel.Models.Input.OrderProduct
{
    public class CreateOrderProductInput
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
