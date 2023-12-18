namespace Library_System.Models.DTO
{
    public class AddBookRequestDto
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Publication { get; set; }
        public string PublicationDate { get; set; }
        public string Edition { get; set; }
        public string RFID { get; set; }
        //public string Status { get; internal set; }
        public int Count { get; internal set; }
    }
}
