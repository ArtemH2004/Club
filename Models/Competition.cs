namespace Club.Models
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int AudienceCount { get; set; }
        public string Result { get; set; } // ???   mb name of win team 
        public string Weather { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public ICollection<Clubs> Clubs { get; set; } = new List<Clubs>();
    }
}
