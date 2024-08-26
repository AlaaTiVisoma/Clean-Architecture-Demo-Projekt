using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
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
        public BookRepositoryMongo(MongoDbContext context)
       : base(context, "Books")
        {
        }
    }
}
