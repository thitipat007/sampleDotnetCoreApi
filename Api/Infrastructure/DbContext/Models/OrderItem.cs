namespace sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Qty { get; set; }
        public Product Product { get; } = null!;
        public Order Order { get; } = null!;
    }
}