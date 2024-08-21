using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(BookStoreDbContext context) : base(context) { }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }
    }
}
