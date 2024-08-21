using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int orderId);
        // Add any other specific methods for OrderItem as needed
    }
}
