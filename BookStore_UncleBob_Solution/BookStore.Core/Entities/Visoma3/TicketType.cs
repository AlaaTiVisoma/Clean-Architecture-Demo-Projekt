using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Visoma3
{
    public class TicketType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ticketTypeId")]
        public string TicketTypeId { get; set; }

        [BsonElement("customerId")]
        public string CustomerId { get; set; }

        [BsonElement("ticketTypeName")]
        public string TicketTypeName { get; set; }

        [BsonElement("fields")]
        public List<Field> Fields { get; set; }
    }
}
