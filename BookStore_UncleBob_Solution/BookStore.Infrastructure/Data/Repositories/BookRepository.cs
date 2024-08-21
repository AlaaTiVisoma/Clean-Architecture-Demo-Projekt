using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

namespace BookStore.Infrastructure.Data.Repositories
{ 

    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext context) : base(context) { }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
        {
            return await _context.Books
                .Where(b => b.Author == author)
                .ToListAsync();
        }
    }
}
