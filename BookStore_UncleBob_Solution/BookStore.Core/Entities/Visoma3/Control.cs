using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Visoma3
{
    public class Control
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("controlName")]
        public string ControlName { get; set; }

        [BsonElement("controlType")]
        public string ControlType { get; set; }

        [BsonElement("displayName")]
        public string DisplayName { get; set; }
    }
}
