using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class GenericRepositoryMongo<T> : IGenericRepositoryMongo<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;
        public GenericRepositoryMongo(MongoDbContext context, string collectionName)
        {
            _collection = context.Database.GetCollection<T>(collectionName);
        }
        public async Task<T> GetByIdAsync(ObjectId id)
        {
            // Assuming the entity has an Id field of type ObjectId
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            // Assuming the entity has an Id field of type ObjectId
            var filter = Builders<T>.Filter.Eq("_id", typeof(T).GetProperty("Id")?.GetValue(entity, null));
            await _collection.ReplaceOneAsync(filter, entity);
        }
        public async Task DeleteAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
