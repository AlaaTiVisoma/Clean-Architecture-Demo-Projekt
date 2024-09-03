using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Entities.Visoma3;

namespace BookStore.Core.Interfaces.Visoma3
{
    namespace BookStore.Core.Interfaces
    {
        public interface ICustomerRepository : IGenericRepositoryVisoma<Customer>
        {
            // Additional methods specific to Customer entity can be added here
        }
    }
}
