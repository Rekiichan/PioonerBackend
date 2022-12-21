using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pioneer_Backend.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("role")]
        public string? Role { get; set; }
    }
}
