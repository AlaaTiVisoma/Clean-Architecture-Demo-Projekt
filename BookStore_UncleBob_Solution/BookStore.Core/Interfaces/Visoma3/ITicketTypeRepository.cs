﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Entities.Visoma3;

namespace BookStore.Core.Interfaces.Visoma3
{
    public interface ITicketTypeRepository : IGenericRepositoryVisoma<TicketType>
    {
        // Additional methods specific to TicketType entity can be added here
    }
}
