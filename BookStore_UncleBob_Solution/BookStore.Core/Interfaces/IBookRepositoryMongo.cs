using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
    public interface IBookRepositoryMongo : IGenericRepositoryMongo<BookMongo>
    {
        // Add any specific methods for books if needed
    }
}
