namespace Club.Models
{
    public class Sponsor
    {
        public int SponsorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public int Percent { get; set; }
        public int ClubsId { get; set; }
        public Clubs Clubs { get; set; }
    }
}
