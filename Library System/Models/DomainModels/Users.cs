namespace Library_System.Models.DomainModels
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool Status { get; set; } = false;

    }
}
