using Microsoft.EntityFrameworkCore;
using sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models;
using sampleDotnetCoreApi.Api.Repositories.IRepositories;

namespace sampleDotnetCoreApi.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Order? GetOrder(int id)
        {
            try
            {
                return _context
                               .orders
                               .Include(e => e.OrderItems)
                                   .ThenInclude(e => e.Product)
                               .Include(e => e.Customer)
                               .Where(order => order.Id == id)
                               .FirstOrDefault();
            }
            catch (Exception exception)
            {
                //REVIEW -  Log error
                return null;
            }
        }

        public List<Order> GetOrders()
        {
            try
            {
                return _context
                               .orders
                               .Include(e => e.OrderItems)
                                   .ThenInclude(e => e.Product)
                               .Include(e => e.Customer)
                               .ToList();
            }
            catch (Exception exception)
            {
                //REVIEW -  Log error
                return new List<Order>();
            }
        }

        public List<Order> GetOrders(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(Order order)
        {
            try
            {
                _context.orders.Add(order);
            }
            catch (Exception exception)
            {

            }
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            try
            {
                _context.orderItems.AddRange(orderItem);
            }
            catch (Exception exception)
            {

            }
        }
    }
}