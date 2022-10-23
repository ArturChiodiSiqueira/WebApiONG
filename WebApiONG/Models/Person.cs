using MongoDB.Bson.Serialization.Attributes;

namespace WebApiONG.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Cpf { get; set; }
        public string Name { get; set; }
        public char Sex { get; set; }
        public string Birth { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}
