using Microsoft.EntityFrameworkCore;
using sampleDotnetCoreApi.Api.Core.Models.Dtos;
using sampleDotnetCoreApi.Api.Core.Models.Request;
using sampleDotnetCoreApi.Api.Core.Models.Responses;
using sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models;
using sampleDotnetCoreApi.Api.Repositories.IRepositories;
using sampleDotnetCoreApi.Services.IServices;

namespace sampleDotnetCoreApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public Task Create(CreateOrderRequest createOrderRequest)
        {
            var productIds = createOrderRequest.order_items.Select(e => e.id).ToList();
            var products = _productRepository.GetProduct(productIds);

            var order = new Order
            {
                CustomerId = createOrderRequest.customer_id,
                CreatedDate = DateTime.Now,
                TotalQty = 0,
                TotalPrice = 0,
            };

            _orderRepository.CreateOrder(order);
            
            throw new NotImplementedException();
        }

        public Task DeleteBy(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrdersResponse> GetAll()
        {
            var orders = _orderRepository.GetOrders();
            return orders.Select(OrderDto.ModelToReponse).ToList();
        }

        public OrdersResponse GetBy(int id)
        {
            var order = _orderRepository.GetOrder(id);
            return OrderDto.ModelToReponse(order);
        }

        public Task UpdateBy(int id)
        {
            throw new NotImplementedException();
        }


    }
}