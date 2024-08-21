using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        // Add any other specific methods for Order as needed
    }
}
