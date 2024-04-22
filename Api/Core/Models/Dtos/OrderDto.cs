using sampleDotnetCoreApi.Api.Core.Models.Responses;
using sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models;

namespace sampleDotnetCoreApi.Api.Core.Models.Dtos
{
    public static class OrderDto
    {
        public static OrdersResponse ModelToReponse(Order order)
        {
            return new OrdersResponse
            {
                customer_name = $"{order.Customer.Name} {order.Customer.LastName}",
                order_date = order?.CreatedDate?.ToString(),
                total_price = order?.TotalPrice,
                total_qty = order?.TotalQty,
                orderItems = order?.OrderItems.Select(orderItem =>
                {
                    return new OrderItemsResponse
                    {
                        name = orderItem.Product.Name,
                        price = orderItem.Product.Price,
                        qty = orderItem.Qty
                    };
                }).ToList()
            };
        }

    }
}