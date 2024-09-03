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
    public class TicketTypeRepository : GenericRepositoryVisoma<TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(VisomaTicketDbContext context) : base(context, ctx => ctx.TicketTypes) { }
        // Add any TicketType-specific methods here
    }
}
