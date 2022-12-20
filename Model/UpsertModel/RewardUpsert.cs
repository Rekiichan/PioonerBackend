using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pioneer_Backend.Model.UpsertModel
{
    public class RewardUpsert
    {
        [BsonElement("memberName")]
        public string? MemberName { get; set; }
        [BsonElement("rewardRank")]
        public string? RewardRank { get; set; }
        [BsonElement("contestName")]
        public string? ContestName { get; set; }
        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; } = null;
        [BsonElement("description")]
        public string? Description { get; set; } = null;
    }
}
