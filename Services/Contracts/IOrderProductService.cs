using BookzoneProjNituDaniel.Models.DTO.Product;

namespace BookzoneProjNituDaniel.Services.Contracts
{
    public interface IOrderProductService
    {
        IEnumerable<ProductReportDTO> GetLast30DaysTop10SalesReport();
    }
}
