using System;
using System.Collections.Generic;
using System.Linq;
using EventEase.Models;

namespace EventEase.Services
{
    /// <summary>
    /// Centralized State Management Service handling user sessions,
    /// dynamic events list, registrations, and attendance tracker state.
    /// </summary>
    public class EventSessionStateService
    {
        public event Action? OnChange;

        public string CurrentUser { get; private set; } = "Mustofa (Participant)";
        public bool IsLoggedIn { get; private set; } = true;

        public List<EventItem> Events { get; private set; } = new();
        public List<Attendee> Attendees { get; private set; } = new();

        public EventSessionStateService()
        {
            SeedInitialData();
        }

        private void SeedInitialData()
        {
            Events = new List<EventItem>
            {
                new EventItem
                {
                    Id = 1,
                    Title = "Global Tech Innovation Summit 2026",
                    Description = "Explore breakthrough advancements in artificial intelligence, cloud architectures, and modern web application frameworks.",
                    Date = DateTime.Today.AddDays(14).AddHours(9),
                    Location = "Tech City Arena & Virtual Hall A",
                    Category = "Technology",
                    Capacity = 150,
                    RegisteredCount = 125,
                    ImageUrl = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?w=600&auto=format&fit=crop&q=80"
                },
                new EventItem
                {
                    Id = 2,
                    Title = "Blazor Fullstack Masterclass with Microsoft Copilot",
                    Description = "Accelerate modern C# full-stack development using Blazor WebAssembly and AI pair programming workflows.",
                    Date = DateTime.Today.AddDays(21).AddHours(14),
                    Location = "Online Interactive Stream",
                    Category = "Workshop",
                    Capacity = 80,
                    RegisteredCount = 65,
                    ImageUrl = "https://images.unsplash.com/photo-1517245386807-bb43f82c33c4?w=600&auto=format&fit=crop&q=80"
                },
                new EventItem
                {
                    Id = 3,
                    Title = "UI/UX Architecture & Modern Design Systems",
                    Description = "Building accessible, high-performance user interfaces and responsive layouts for enterprise web applications.",
                    Date = DateTime.Today.AddDays(28).AddHours(10),
                    Location = "Design Lab Auditorium, Floor 3",
                    Category = "Design",
                    Capacity = 60,
                    RegisteredCount = 45,
                    ImageUrl = "https://images.unsplash.com/photo-1531403009284-440f080d1e12?w=600&auto=format&fit=crop&q=80"
                }
            };

            Attendees = new List<Attendee>
            {
                new Attendee
                {
                    FullName = "Mustofa",
                    Email = "mustofa@coursera.user",
                    EventId = 1,
                    EventTitle = "Global Tech Innovation Summit 2026",
                    Tickets = 2,
                    IsCheckedIn = true,
                    CheckInTime = DateTime.Now.AddHours(-1)
                },
                new Attendee
                {
                    FullName = "Sarah Jenkins",
                    Email = "sarah.j@example.com",
                    EventId = 1,
                    EventTitle = "Global Tech Innovation Summit 2026",
                    Tickets = 1,
                    IsCheckedIn = false
                },
                new Attendee
                {
                    FullName = "David Chen",
                    Email = "david.c@example.com",
                    EventId = 2,
                    EventTitle = "Blazor Fullstack Masterclass with Microsoft Copilot",
                    Tickets = 1,
                    IsCheckedIn = true,
                    CheckInTime = DateTime.Now.AddMinutes(-30)
                },
                new Attendee
                {
                    FullName = "Aisha Patel",
                    Email = "aisha.p@example.com",
                    EventId = 3,
                    EventTitle = "UI/UX Architecture & Modern Design Systems",
                    Tickets = 1,
                    IsCheckedIn = false
                }
            };
        }

        public void SetUserSession(string userName)
        {
            CurrentUser = userName;
            IsLoggedIn = !string.IsNullOrWhiteSpace(userName);
            NotifyStateChanged();
        }

        public bool RegisterAttendee(RegistrationModel model)
        {
            var targetEvent = Events.FirstOrDefault(e => e.Id == model.SelectedEventId);
            if (targetEvent == null || targetEvent.AvailableSeats < model.NumberOfTickets)
            {
                return false;
            }

            targetEvent.RegisteredCount += model.NumberOfTickets;

            var attendee = new Attendee
            {
                FullName = model.FullName,
                Email = model.Email,
                EventId = targetEvent.Id,
                EventTitle = targetEvent.Title,
                Tickets = model.NumberOfTickets,
                RegisteredAt = DateTime.Now,
                IsCheckedIn = false
            };

            Attendees.Insert(0, attendee);
            NotifyStateChanged();
            return true;
        }

        public void ToggleAttendance(Guid attendeeId)
        {
            var attendee = Attendees.FirstOrDefault(a => a.Id == attendeeId);
            if (attendee != null)
            {
                attendee.IsCheckedIn = !attendee.IsCheckedIn;
                attendee.CheckInTime = attendee.IsCheckedIn ? DateTime.Now : null;
                NotifyStateChanged();
            }
        }

        public void UpdateEvent(EventItem updatedEvent)
        {
            var index = Events.FindIndex(e => e.Id == updatedEvent.Id);
            if (index >= 0)
            {
                Events[index] = updatedEvent;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
