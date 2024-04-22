namespace sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
        public Customer Customer { get; set; } = null!;
    }
}