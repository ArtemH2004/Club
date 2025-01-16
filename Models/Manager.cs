namespace Club.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public int Amount { get; set; }
        public int ClubsId { get; set; }
        public Clubs Clubs { get; set; }
    }
}
