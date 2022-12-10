using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Pioneer_Backend.Model
{
    [DynamoDBTable("Rewards")]
    public class RewardList
    {
        [DynamoDBHashKey("rewardId")]
        public string RewardId { get; set; }
        [DynamoDBProperty("memberName")]
        public string MemberName { get; set; }
        [DynamoDBProperty("mssv")]
        public string Mssv { get; set; }
        [DynamoDBProperty("rewardRank")]
        public string RewardRank { get; set; }
        [DynamoDBProperty("contestName")]
        public string ContestName { get; set; }
        [DynamoDBProperty("imageUrl")]
        public string? ImageUrl { get; set; } = null;
    }
}
