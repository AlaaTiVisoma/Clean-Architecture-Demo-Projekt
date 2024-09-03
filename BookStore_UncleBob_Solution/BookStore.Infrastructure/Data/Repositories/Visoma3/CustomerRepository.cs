using BookStore.Core.Entities.Visoma3;
using BookStore.Core.Interfaces.Visoma3.BookStore.Core.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Data.Repositories.Visoma3
{
    public class CustomerRepository : GenericRepositoryVisoma<Customer>, ICustomerRepository
    {    
        public CustomerRepository(VisomaTicketDbContext context) : base(context, ctx => ctx.Customers) { }

        // Add any Customer-specific methods here
    }
}
