using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.DTOs;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItemDto>> GetItemsByOrderIdAsync(int orderId);
    Task<OrderItemDto> GetOrderItemByIdAsync(int orderItemId);
    Task AddOrderItemAsync(OrderItemDto orderItemDto);
    Task UpdateOrderItemAsync(OrderItemDto orderItemDto);
    Task DeleteOrderItemAsync(int orderItemId);
}
