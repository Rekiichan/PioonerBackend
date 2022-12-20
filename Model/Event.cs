using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pioneer_Backend.Model
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int EventId { get; set; }
        [BsonElement("eventName")]
        public string EventName { get; set; }
        [BsonElement("eventDate")]
        public DateTime EventDate { get; set; }
        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }
        [BsonElement("description")]
        public string? Description { get; set; } = null;
    }
}
