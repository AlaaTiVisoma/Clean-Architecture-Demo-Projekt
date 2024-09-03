using BookStore.Core.Entities.Visoma3;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Data
{
    public class VisomaTicketDbContext
    {
        private readonly IMongoDatabase _database;

        public VisomaTicketDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase Database => _database;
        public IMongoCollection<Control> Controls => _database.GetCollection<Control>("Controls");
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");
        public IMongoCollection<TicketType> TicketTypes => _database.GetCollection<TicketType>("TicketTypes");
        public IMongoCollection<Ticket> Tickets => _database.GetCollection<Ticket>("Tickets");
        public IMongoCollection<TicketData> TicketData => _database.GetCollection<TicketData>("TicketData");
    }
}
