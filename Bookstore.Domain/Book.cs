using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Bookstore.Domain
{
    public class Book
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("bookName")]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Genere { get; set; }
    }
}
