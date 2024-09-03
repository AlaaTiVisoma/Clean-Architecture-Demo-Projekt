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
    public class ControlRepository : GenericRepositoryVisoma<Control>, IControlRepository
    {
        public ControlRepository(VisomaTicketDbContext context) : base(context, ctx => ctx.Controls) { }

        // Add any Control-specific methods here
    }
}
