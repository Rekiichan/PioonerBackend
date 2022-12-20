using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Pioneer_Backend.Model
{
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ProjectId { get; set; }
        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }
        [BsonElement("projectName")]
        public string? ProjectName { get; set; }
        [BsonElement("yearImplement")]
        public int? YearImplement { get; set; }
        [BsonElement("documentUrl")]
        public string? DocumentUrl { get; set; } = null;
        [BsonElement("description")]
        public string? Description { get; set; } = null;
    }
}
