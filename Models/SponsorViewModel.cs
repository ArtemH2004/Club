using System.ComponentModel.DataAnnotations;

namespace Club.Models
{
    public class SponsorViewModel
    {
        public int SponsorId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Percent { get; set; }
        [Required]
        public int ClubsId { get; set; }
    }
}
