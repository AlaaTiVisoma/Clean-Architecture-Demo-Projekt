using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(BookStoreDbContext context) : base(context) { }
        // Implement any additional methods defined in ICategoryRepository

    }
}
