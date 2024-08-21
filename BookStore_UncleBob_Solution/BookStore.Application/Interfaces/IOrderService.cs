using BookStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId);
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(OrderDto orderDto);
        Task UpdateOrderAsync(OrderDto orderDto);
        Task DeleteOrderAsync(int orderId);
    }
}
