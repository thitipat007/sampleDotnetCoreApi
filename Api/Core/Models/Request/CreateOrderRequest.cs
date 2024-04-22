namespace sampleDotnetCoreApi.Api.Core.Models.Request
{
    public class CreateOrderRequest
    {
        public int customer_id { get; set; }
        public List<CreateOrderItemRequest> order_items { get; set; }
    }
}