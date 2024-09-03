using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Visoma3
{
    public class TicketData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ticketId")]
        public string TicketId { get; set; }

        [BsonElement("customerId")]
        public string CustomerId { get; set; }

        [BsonElement("ticketTypeId")]
        public string TicketTypeId { get; set; }

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("data")]
        public Dictionary<string, string> Data { get; set; }
    }
}
