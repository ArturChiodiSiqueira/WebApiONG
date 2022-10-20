using MongoDB.Bson.Serialization.Attributes;
using System.Net;

namespace WebApiONG.Models
{
    public class Animal
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Chip { get; set; }
        public string Family { get; set; }
        public string Breed { get; set; }
        public char Sex { get; set; }
        public string Name { get; set; }
    }
}
