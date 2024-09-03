using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Visoma3
{
    public class Field
    {
        [BsonElement("fieldName")]
        public string FieldName { get; set; }

        [BsonElement("controlId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ControlId { get; set; }
    }
}
