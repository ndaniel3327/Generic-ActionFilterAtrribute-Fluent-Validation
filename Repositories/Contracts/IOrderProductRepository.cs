using BookzoneProjNituDaniel.Models;

namespace BookzoneProjNituDaniel.Repositories.Contracts
{
    public interface IOrderProductRepository
    {
        IQueryable<OrderProduct> GetOrderProductsByDateRange(DateTime startDate, DateTime endDate);
    }
}
