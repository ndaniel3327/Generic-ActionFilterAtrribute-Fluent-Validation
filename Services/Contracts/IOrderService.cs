using BookzoneProjNituDaniel.Models.Input.Order;

namespace BookzoneProjNituDaniel.Services.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(CreateOrderInput input);
    }
}
