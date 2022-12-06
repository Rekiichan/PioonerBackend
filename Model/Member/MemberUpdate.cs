using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pioneer_Backend.Model.Member
{
    public class MemberUpdate
    {
        [Required]
        public int Id { get; set; }
        public string? NameID { get; set; } = null;
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mssv { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [DisplayName("Thế mạnh")]
        public string Strenghs { get; set; }
        [Required]
        [DisplayName("Nhiệm kỳ")]
        public string Term { get; set; }
        [Required]
        [DisplayName("Lớp")]
        public string Class { get; set; }
        [DisplayName("Link Facebook")]
        public string? Facebook { get; set; } = null;
        public string? Gmail { get; set; } = null;
        public string? GitHub { get; set; } = null;
        public string? Linkedin { get; set; } = null;
        public string? CV { get; set; } = null;
        public string? Describe { get; set; } = null;

    }
}
