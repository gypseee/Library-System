namespace Library_System.Models.DomainModels
{
    public class Profiles
    {
        public Guid Id { get; set; }
        public Users User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string RFID { get; set; }
        public int NumberofBooksAllocated { get; set; } = 0;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public string Role { get; set; }
        public bool Verified { get; set; } = false;
    }
}
