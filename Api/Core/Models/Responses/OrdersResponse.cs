namespace sampleDotnetCoreApi.Api.Core.Models.Responses
{
    public class OrdersResponse
    {
        public string? customer_name { get; set; }
        public string? order_date { get; set; }
        public decimal? total_price { get; set; }
        public decimal? total_qty { get; set; }
        public List<OrderItemsResponse>? orderItems { get; set; }
    }
}