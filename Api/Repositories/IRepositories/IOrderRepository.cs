using sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models;

namespace sampleDotnetCoreApi.Api.Repositories.IRepositories
{
    public interface IOrderRepository
    {
        public Order? GetOrder(int id);
        public List<Order> GetOrders();
        void CreateOrder(Order order);
        void CreateOrderItem(OrderItem orderItem);
    }
}