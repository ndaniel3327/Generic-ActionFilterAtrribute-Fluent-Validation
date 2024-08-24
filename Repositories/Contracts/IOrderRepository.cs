using BookzoneProjNituDaniel.Models;

namespace BookzoneProjNituDaniel.Repositories.Contracts
{
    public interface IOrderRepository
    {
        int CreateOrder(Order order);
    }
}
