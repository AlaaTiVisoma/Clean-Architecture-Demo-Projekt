using BookStore.Core.Entities.Visoma3;
using BookStore.Core.Interfaces.Visoma3;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Data.Repositories.Visoma3
{
    public class TicketDataRepository : GenericRepositoryVisoma<TicketData>, ITicketDataRepository
    {/*
        public TicketDataRepository(IMongoDatabase database) : base(database, "TicketData")
        {
        }
        */
        public TicketDataRepository(VisomaTicketDbContext context) : base(context, ctx => ctx.TicketData) { }


        // Add any TicketData-specific methods here
    }
}
