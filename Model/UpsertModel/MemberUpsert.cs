using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Pioneer_Backend.Model.UpsertModel
{
    public class MemberUpsert
    {
        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; } = null!;
        [BsonElement("mssv")]
        public int? Mssv { get; set; }
        [BsonElement("role")]
        public string? Role { get; set; }
        [BsonElement("position")]
        public string? Position { get; set; }
        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }
        [BsonElement("strenghs")]
        public List<string>? Strenghs { get; set; }
        [BsonElement("term")]
        public string? Term { get; set; }
        [BsonElement("class")]
        public string? Class { get; set; }
        [BsonElement("contact")]
        public ContactModel? Contact { get; set; }
        [BsonElement("description")]
        public string? Description { get; set; } = null;
    }
}
