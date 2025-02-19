namespace EventManagementBackend.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public DateTime BookingDate { get; set; }
        public string? Status { get; set; }
    }
}
