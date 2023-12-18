namespace Library_System.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string RFID { get; set; }
        public int NumberofBooksAllocated { get;  set; }
        public DateTime RegistrationDate { get;  set; }

        public string Role { get; set; }
        public bool Verified { get;  set; }
        public bool IsAdmin { get;  set; }
        public bool Status { get;  set; }
    }
}
