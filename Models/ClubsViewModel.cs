using System.ComponentModel.DataAnnotations;

namespace Club.Models
{
    public class ClubsViewModel
    {
        public int ClubsId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDeate { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int CompetitionId { get; set; }
        [Required]
        public int FieldId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
