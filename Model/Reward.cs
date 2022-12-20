using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Pioneer_Backend.Model
{
    public class Reward
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? RewardId { get; set; }
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
