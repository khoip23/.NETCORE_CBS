using System.ComponentModel.DataAnnotations;

namespace HomeWork_Day27.ViewModels
{
    public class CustomerContactVM
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Full Name must be at least 3 characters long.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Phone number must be 10-12 digits.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number must contain only digits.")]
        public string? PhoneNumber { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be at least 5 characters long.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Message must be at least 10 characters long.")]
        public string? Message { get; set; }

        [Required(ErrorMessage = "Please select a service.")]
        [RegularExpression(@"^(?!Choose\.\.\.).*$", ErrorMessage = "Please select a valid service.")]
        public string? SelectedService { get; set; }

        [Required(ErrorMessage = "You must agree before submitting.")]
        public bool? AgreeToTerms { get; set; }
    }
}
