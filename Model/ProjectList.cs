using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pioneer_Backend
{
    [DynamoDBTable("Projects")]
    public class ProjectList
    {
        [DynamoDBHashKey("projectId")]
        public string ProjectId { get; set; }
        [DynamoDBProperty("name")]
        public string Name { get; set; }
        [DynamoDBProperty("mssv")]
        public string Mssv { get; set; }
        [DynamoDBProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [DynamoDBProperty("projectName")]
        public string ProjectName { get; set; }
        [DynamoDBProperty("yearImplement")]
        public int YearImplement { get; set; } = 2022;
        [DynamoDBProperty("documentUrl")]
        public string? DocumentUrl { get; set; } = null;
        [DynamoDBProperty("description")]
        public string? Description { get; set; } = null;
    }
}
