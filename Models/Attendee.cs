using System;

namespace EventEase.Models
{
    public class Attendee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public int Tickets { get; set; } = 1;
        public DateTime RegisteredAt { get; set; } = DateTime.Now;
        public bool IsCheckedIn { get; set; } = false;
        public DateTime? CheckInTime { get; set; }
    }
}
