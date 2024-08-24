using BookzoneProjNituDaniel.Models;
using BookzoneProjNituDaniel.Models.DTO.Product;
using BookzoneProjNituDaniel.Repositories.Contracts;
using BookzoneProjNituDaniel.Services.Contracts;

namespace BookzoneProjNituDaniel.Services.Implementations
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderProductService(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }

        public IEnumerable<ProductReportDTO> GetLast30DaysTop10SalesReport()
        {
            var startDate= DateTime.UtcNow.AddDays(-30);
            var endDate = DateTime.UtcNow;

            var orderProductsInLast30Days = _orderProductRepository.GetOrderProductsByDateRange(startDate,endDate);

            return orderProductsInLast30Days.GroupBy(op => new { op.ProductId, op.Product.Name })
                .Select(x => new ProductReportDTO
                {
                    ProductName = x.Key.Name,
                    UnitsSold = x.Sum(y => y.Quantity),
                    TotalIncomeGenerated = x.Sum(y => y.Quantity * y.Price),
                })
                .OrderByDescending(x => x.UnitsSold)
                .Take(10)
                .ToList();
        }
    }
}
