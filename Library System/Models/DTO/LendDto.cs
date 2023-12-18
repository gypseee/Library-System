using Library_System.Models.DomainModels;

namespace Library_System.Models.DTO
{
    public class LendDto
    {
        public Guid Id { get; set; }
        public Books Book { get; set; }
        public Profiles Profile { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
