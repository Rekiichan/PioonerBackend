
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Pioneer_Backend.Model
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        public string? Description { get; set; } = null;
    }
}
