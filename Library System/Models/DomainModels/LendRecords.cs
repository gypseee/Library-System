namespace Library_System.Models.DomainModels
{
    public class LendRecords
    {
        public Guid Id { get; set; }
        public Books Book { get; set; }
        public Profiles Profile { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime? CheckInDate { get; set;}
        public DateTime DueDate { get; set; }
    }
}
