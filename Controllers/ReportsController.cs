using BookzoneProjNituDaniel.Models.DTO.Product;
using BookzoneProjNituDaniel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookzoneProjNituDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IOrderProductService _orderProductService;

        public ReportsController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }


        [HttpGet("last-30days-top10-selling-products")]
        public ActionResult<List<ProductReportDTO>> GetReportLast30DayTop10SellingProducts()
        {
            var report = _orderProductService.GetLast30DaysTop10SalesReport();
            return Ok(report);
        }
    }
}
