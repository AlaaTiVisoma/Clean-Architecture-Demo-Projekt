using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Interfaces;
using BookStore.Core.Interfaces.Visoma3;
using MongoDB.Driver;
namespace BookStore.Infrastructure.Data.Repositories.Visoma3
{
    public class GenericRepositoryVisoma<T> : IGenericRepositoryVisoma<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        public GenericRepositoryVisoma(VisomaTicketDbContext context, Func<VisomaTicketDbContext, IMongoCollection<T>> collectionAccessor)
        {
            _collection = collectionAccessor(context);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        }
    }
}
