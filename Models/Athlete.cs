namespace Club.Models
{
    public class Athlete
    {
        public int AthleteId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber {  get; set; }
        public string Address { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public byte[]? Photo { get; set; }
        public int ClubsId { get; set; }
        public Clubs Clubs { get; set; }

    }
}
