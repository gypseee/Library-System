using Library_System.Models.DomainModels;

namespace Library_System.Models.DTO
{
    public class AddLendRecordDto
    {
        public Books Book { get; set; }
        public Profiles Profile { get; set; }
    }
}
