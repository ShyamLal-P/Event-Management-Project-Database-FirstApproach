namespace EventManagementBackend.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public DateTime SubmittedTimestamp { get; set; }
    }
}
