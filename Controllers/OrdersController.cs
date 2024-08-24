using BookzoneProjNituDaniel.CustomFilters;
using BookzoneProjNituDaniel.Models.Input.Order;
using BookzoneProjNituDaniel.Models.Validators.Order;
using BookzoneProjNituDaniel.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookzoneProjNituDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [ValidatorFilter<CreateOrderValidator, CreateOrderInput>(InputVariableName = "input")]
        public IActionResult CreateOrder(CreateOrderInput input)
        {
            _orderService.CreateOrder(input);
            return NoContent();
        }
    }
}
