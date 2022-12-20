using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Pioneer_Backend.Model
{
    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? MemberId { get; set; }
        [BsonElement("nameID")]
        public string? NameID { get; set; } = null;
        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [BsonElement("mssv")]
        public int Mssv { get; set; }
        [BsonElement("role")]
        public string Role { get; set; }
        [BsonElement("position")]
        public string Position { get; set; }
        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }
        [BsonElement("strenghs")]
        public List<string> Strenghs { get; set; }
        [BsonElement("term")]
        public string Term { get; set; }
        [BsonElement("class")]
        public string Class { get; set; }
        [BsonElement("facebook")]
        public string? Facebook { get; set; } = null;
        [BsonElement("gmail")]
        public string? Gmail { get; set; } = null;
        [BsonElement("gitHub")]
        public string? GitHub { get; set; } = null;
        [BsonElement("linkedin")]
        public string? Linkedin { get; set; } = null;
        [BsonElement("cv")]
        public string? CV { get; set; } = null;
        [BsonElement("description")]
        public string? Description { get; set; } = null;
    }
}
