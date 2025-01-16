namespace Club.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public string Job { get; set; }
        public int Amount { get; set; }
        public int ClubsId { get; set; }
        public Clubs Clubs { get; set; }
    }
}
