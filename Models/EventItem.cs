using System;

namespace EventEase.Models
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Today.AddDays(7);
        public string Location { get; set; } = string.Empty;
        public string Category { get; set; } = "Technology";
        public int Capacity { get; set; } = 100;
        public int RegisteredCount { get; set; } = 0;
        public string ImageUrl { get; set; } = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?w=600&auto=format&fit=crop&q=80";

        public int AvailableSeats => Math.Max(0, Capacity - RegisteredCount);
        public bool IsSoldOut => AvailableSeats == 0;
    }
}
