using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Entities.Visoma3;

namespace BookStore.Core.Interfaces.Visoma3
{
    public interface ITicketRepository : IGenericRepositoryVisoma<Ticket>
    {
        // Additional methods specific to Ticket entity can be added here
    }
}
