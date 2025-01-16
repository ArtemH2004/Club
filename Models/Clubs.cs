namespace Club.Models
{
    public class Clubs
    {
        public int ClubsId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDeate { get; set; }
        public string Address { get; set; }
        public byte[]? Photo { get; set; }
        public ICollection<Athlete> Athletes { get; set; } = new List<Athlete>();
        public ICollection<Sponsor> Sponsors { get; set; } = new List<Sponsor>();
        public ICollection<Manager> Managers { get; set; } = new List<Manager>();
        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }

    }
}
