﻿namespace EventManagementBackend.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ContactNumber { get; set; }
    }
}
