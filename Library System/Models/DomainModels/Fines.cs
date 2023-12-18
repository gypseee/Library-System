namespace Library_System.Models.DomainModels
{
    public class Fines
    {
        public Guid Id { get; set; }
        public Profiles Profile { get; set; }
        public float Amount { get; set; }
        public DateTime FineDate { get; set; }
        public bool PaymentStatus { get; set; }

    }
}
