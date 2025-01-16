namespace Club.Models
{
    public class Field
    {
        public int FieldId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[]? Photo { get; set; }
        public int ClubsId { get; set; }
        public Clubs Clubs { get; set; }

    }
}
