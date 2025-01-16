using System.ComponentModel.DataAnnotations;

namespace Club.Models
{
    public class AthleteViewModel
    {
        public int AthleteId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string PhoneNumber {  get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public int ClubsId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
