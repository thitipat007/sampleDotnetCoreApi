namespace sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    }
}