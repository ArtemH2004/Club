using System.ComponentModel.DataAnnotations;

namespace Club.Models
{
    public class CompetitionViewModel
    {
        public int CompetitionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int AudienceCount { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public string Weather { get; set; }
        [Required]
        public int FieldId { get; set; }
    }
}
