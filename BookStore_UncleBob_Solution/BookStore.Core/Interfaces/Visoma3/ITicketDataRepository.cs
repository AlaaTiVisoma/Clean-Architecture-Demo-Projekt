using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Entities.Visoma3;

namespace BookStore.Core.Interfaces.Visoma3
{
    public interface ITicketDataRepository : IGenericRepositoryVisoma<TicketData>
    {
        // Additional methods specific to TicketData entity can be added here
    }
}
