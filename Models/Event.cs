using System.ComponentModel.DataAnnotations;

namespace EventManagementBackend.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Location { get; set; }
        public DateTime Date { get; set; }
        public int OrganizerID { get; set; }
    }
}

