using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pioneer_Backend.Model
{
    public class Member
    {
        [Key]
        public int Id { get; set; } //mssv
        [Required]
        public string NameID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        public string Strenghs { get; set; }
        [Required]
        public string Term { get; set; }
        [Required]
        public string Class { get; set; }
        public string Describe { get; set; }
        [Required]
        public int ContactInfoId { get; set; }
        [ForeignKey("ContactInfoId")]
        [ValidateNever]
        public ContactInfo ContactInfo { get; set; }

        [Required]
        public int RewardId { get; set; }
        [ForeignKey("RewardId")]
        [ValidateNever]
        public ICollection<RewardCollection> Rewards { get; set; }

        [Required]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        [ValidateNever]
        public ICollection<ProjectCollection> Projects{ get; set; }
    }
}
