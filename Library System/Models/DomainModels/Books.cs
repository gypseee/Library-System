namespace Library_System.Models.DomainModels
{
    public class Books
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Publication { get; set; }
        public string PublicationDate { get; set; }
        public string Edition { get; set;}
        public int Count { get; set; }
        public string RFID { get; set; }
        public bool Status { get; set; }
    }
}
