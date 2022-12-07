using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pioneer_Backend
{
    [DynamoDBTable("members")]
    public class Member
    {
        [DynamoDBHashKey("id")]
        public int Id { get; set; }
        [DynamoDBProperty("nameID")]
        public string? NameID { get; set; } = null;
        [DynamoDBProperty("name")]
        public string Name { get; set; }
        [DynamoDBProperty("mssv")]
        public string Mssv { get; set; }
        [DynamoDBProperty("role")]
        public string Role { get; set; }
        [DynamoDBProperty("position")]
        public string Position { get; set; }
        [DynamoDBProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [DynamoDBProperty("strenghs")]
        public string Strenghs { get; set; }
        [DynamoDBProperty("term")]
        public string Term { get; set; }
        [DynamoDBProperty("class")]
        public string Class { get; set; }
        [DynamoDBProperty("facebook")]
        public string? Facebook { get; set; } = null;
        [DynamoDBProperty("gmail")]
        public string? Gmail { get; set; } = null;
        [DynamoDBProperty("gitHub")]
        public string? GitHub { get; set; } = null;
        [DynamoDBProperty("linkedin")]
        public string? Linkedin { get; set; } = null;
        [DynamoDBProperty("cv")] 
        public string? CV { get; set; } = null;
        [DynamoDBProperty("describe")]
        public string? Describe { get; set; } = null;

    }
}
