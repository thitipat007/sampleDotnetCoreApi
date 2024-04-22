using sampleDotnetCoreApi.Api.Core.Models.Request;
using sampleDotnetCoreApi.Api.Core.Models.Responses;

namespace sampleDotnetCoreApi.Services.IServices
{
    public interface IOrderService
    {
        List<OrdersResponse> GetAll();
        OrdersResponse GetBy(int id);
        Task Create(CreateOrderRequest createOrderRequest);
        Task UpdateBy(int id);
        Task DeleteBy(int id);
    }
}