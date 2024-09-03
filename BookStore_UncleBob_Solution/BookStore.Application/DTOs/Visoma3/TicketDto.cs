using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs.Visoma3
{
    public class TicketDto
    {
        public string Id { get; set; }
        public string TicketId { get; set; }
        public string CustomerId { get; set; }
        public string TicketTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
