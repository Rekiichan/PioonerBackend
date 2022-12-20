using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pioneer_Backend.Model
{
    public class ContactModel
    {
        [BsonElement("facebook")]
        public string? Facebook { get; set; } = null;
        [BsonElement("gmail")]
        public string? Gmail { get; set; } = null;
        [BsonElement("gitHub")]
        public string? GitHub { get; set; } = null;
        [BsonElement("linkedin")]
        public string? Linkedin { get; set; } = null;
    }
}
