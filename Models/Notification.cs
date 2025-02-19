namespace EventManagementBackend.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public string? Message { get; set; }
        public DateTime SentTimestamp { get; set; }
    }
}
