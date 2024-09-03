using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs.Visoma3
{
    public class TicketTypeDto
    {
        public string Id { get; set; }
        public string TicketTypeId { get; set; }
        public string CustomerId { get; set; }
        public string TicketTypeName { get; set; }
        public List<FieldDto> Fields { get; set; }
    }
}
