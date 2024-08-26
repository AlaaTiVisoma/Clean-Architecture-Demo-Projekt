using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace BookStore.Core.Entities
{
    public class BookMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // MongoDB's ObjectId is usually represented as a string in .NET

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("stock")]
        public int Stock { get; set; }

        [BsonElement("numberOfPages")]
        public int NumberOfPages { get; set; }

        [BsonElement("publishedDate")]
        public DateTime PublishedDate { get; set; }

        [BsonElement("discountedPrice")]
        public decimal DiscountedPrice { get; set; }

        [BsonElement("isDiscounted")]
        public bool IsDiscounted { get; set; }
    }
}
