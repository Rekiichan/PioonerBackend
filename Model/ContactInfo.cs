using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pioneer_Backend.Model
{
    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }
        public string Facebook { get; set; }
        public string Gmail{ get; set; }
        public string GitHub { get; set; }
        public string Linkedin { get; set; }
        public string CV { get; set; }
    }
}
