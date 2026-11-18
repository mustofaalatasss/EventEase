using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 60 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address (e.g. user@example.com).")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?[0-9\s\-()]{7,20}$", ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select an event.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid event.")]
        public int SelectedEventId { get; set; }

        [Required(ErrorMessage = "Please specify ticket quantity.")]
        [Range(1, 5, ErrorMessage = "You can book between 1 and 5 tickets.")]
        public int NumberOfTickets { get; set; } = 1;

        public string SessionNotes { get; set; } = string.Empty;

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the Terms and Conditions.")]
        public bool AgreedToTerms { get; set; } = false;
    }
}
