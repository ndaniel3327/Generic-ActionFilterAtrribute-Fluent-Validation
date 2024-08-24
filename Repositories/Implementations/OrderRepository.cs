using BookzoneProjNituDaniel.Data;
using BookzoneProjNituDaniel.Models;
using BookzoneProjNituDaniel.Repositories.Contracts;

namespace BookzoneProjNituDaniel.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int CreateOrder(Order order)
        {
            _dataContext.Orders.Add(order);
            return order.Id;
        }
    }
}
