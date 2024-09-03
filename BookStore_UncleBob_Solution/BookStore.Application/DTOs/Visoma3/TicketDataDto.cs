using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs.Visoma3
{
    public class TicketDataDto
    {
        public string Id { get; set; }
        public string TicketId { get; set; }
        public string CustomerId { get; set; }
        public string TicketTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}
