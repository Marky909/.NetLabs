using EcommerceApi.DTOs;

namespace EcommerceApi.Services
{
    public interface IOrderService
    {
        Task<int> CheckOutAsync();
        Task<List<OrderResponse>> GetMyOrdersAsync();
        Task<OrderResponse?> GetMyOrderAsync(int orderId);
        Task<List<SellerOrderItemResponse>> GetSellerOrdersAsync();

        Task UpdateOrderStatusAsync(
            int orderItemId,
            string newStatus);

        Task<List<AdminOrderResponse>> GetAdminOrdersAsync();
    }
}
