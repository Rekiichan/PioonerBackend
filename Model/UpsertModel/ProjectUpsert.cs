using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Pioneer_Backend.Model.UpsertModel
{
    public class ProjectUpsert
    {
        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [BsonElement("mssv")]
        public string Mssv { get; set; }
        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }
        [BsonElement("projectName")]
        public string ProjectName { get; set; }
        [BsonElement("yearImplement")]
        public int YearImplement { get; set; }
        [BsonElement("documentUrl")]
        public string? DocumentUrl { get; set; } = null;
        [BsonElement("description")]
        public string? Description { get; set; } = null;
    }
}
