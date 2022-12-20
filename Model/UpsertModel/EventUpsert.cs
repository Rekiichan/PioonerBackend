using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pioneer_Backend.Model.UpsertModel
{
    public class EventUpsert
    {
        [BsonElement("eventName")]
        public string? EventName { get; set; }
        [BsonElement("eventDate")]
        public DateTime? EventDate { get; set; }
        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }
        [BsonElement("description")]
        public string? Description { get; set; } = null;
    }
}
