using AutoMapper;
using BookzoneProjNituDaniel.Models;
using BookzoneProjNituDaniel.Models.Input.Order;
using BookzoneProjNituDaniel.Repositories.Contracts;
using BookzoneProjNituDaniel.Services.Contracts;

namespace BookzoneProjNituDaniel.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public void CreateOrder(CreateOrderInput input)
        {
            var order = new Order
            {
                UserId = input.UserId,
            };
            var orderProducts = _mapper.Map<List<OrderProduct>>(input.OrderProducts);

            order.OrderProducts = orderProducts;

            _orderRepository.CreateOrder(order);

        }
    }
}
