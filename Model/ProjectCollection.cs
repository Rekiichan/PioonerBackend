using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Pioneer_Backend.Model
{
    public class ProjectCollection
    {
        [Key]
        public int Id { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public int YearImplement { get; set; }
        public string DocumentUrl { get; set; }
        public string Description { get; set; }

    }
}
