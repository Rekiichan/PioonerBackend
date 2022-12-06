using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Pioneer_Backend.Model
{
    public class RewardCollection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mssv { get; set; }
        [Required]
        public string ContestName { get; set; }
        [Required]
        public string Rank { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; } = null;
    }
}
