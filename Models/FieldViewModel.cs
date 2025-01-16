using System.ComponentModel.DataAnnotations;

namespace Club.Models
{
    public class FieldViewModel
    {
        public int FieldId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int ClubsId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
