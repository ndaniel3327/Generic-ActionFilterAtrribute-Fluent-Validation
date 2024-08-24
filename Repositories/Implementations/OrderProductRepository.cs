using BookzoneProjNituDaniel.Data;
using BookzoneProjNituDaniel.Models;
using BookzoneProjNituDaniel.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookzoneProjNituDaniel.Repositories.Implementations
{
    public class OrderProductRepository:IOrderProductRepository
    {
        private readonly DataContext _context;

        public OrderProductRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<OrderProduct> GetOrderProductsByDateRange(DateTime startDate,DateTime endDate)
        {
            return _context.OrderProducts
                .Include(x => x.Product)
                .Include(x => x.Order)
                .Where(x => startDate<= x.Order.DateAdded && x.Order.DateAdded >= endDate);
        }
    }
}
