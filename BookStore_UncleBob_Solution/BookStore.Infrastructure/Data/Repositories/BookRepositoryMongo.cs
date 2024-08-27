using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class BookRepositoryMongo : GenericRepositoryMongo<BookMongo>, IBookRepositoryMongo    
    {
        public BookRepositoryMongo(MongoDbContext context) : base(context, "Books"){ }

        public async Task<IEnumerable<BookMongo>> GetBooksByAuthorAsync(string author)
        {

            // Use MongoDB's filter to find books by author
            var filter = Builders<BookMongo>.Filter.Eq(b => b.Author, author);

            // Execute the query and return the results as a list
            return await _collection.Find(filter).ToListAsync();
        }
    }
}
