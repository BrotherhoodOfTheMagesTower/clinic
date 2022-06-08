using Clinic.Areas.Identity.Data;
using Clinic.Data.Enums;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Data.Models
{
    public class Patient
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The first name is required")]
        [MaxLength(30, ErrorMessage = "The first name should have maximum 30 characters")]
        [MinLength(3, ErrorMessage = "The first name should have at least 3 characters.")]
        [RegularExpression(@"^[\p{L}\p{M}' \.\-]+$", ErrorMessage = "First name must be properly formatted.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        [MaxLength(30, ErrorMessage = "The last name should have maximum 30 characters")]
        [MinLength(3, ErrorMessage = "The last name should have at least 3 characters.")]
        [RegularExpression(@"^[\p{L}\p{M}' \.\-]+$", ErrorMessage = "Last name must be properly formatted.")]
        public string LastName { get; set; }


        public string? Pesel { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Phone number is not valid.")]
        public string? PhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public Address? Address { get; set; }
    }
}
