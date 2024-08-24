using BookzoneProjNituDaniel.Models.Input.OrderProduct;

namespace BookzoneProjNituDaniel.Models.Input.Order
{
    public class CreateOrderInput:InputBase
    {
        public int UserId { get; set; }
        public List<CreateOrderProductInput> OrderProducts { get; set; } = new List<CreateOrderProductInput>();
    }
}
