using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // Additional methods specific to Category can be added here
    }
}
