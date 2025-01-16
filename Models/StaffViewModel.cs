using System.ComponentModel.DataAnnotations;

namespace Club.Models
{
    public class StaffViewModel
    {
        public int StaffId { get; set; }
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
        public string Job { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int ClubsId { get; set; }
    }
}
