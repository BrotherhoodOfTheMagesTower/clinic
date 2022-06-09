using Clinic.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class Address
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The street is required")]
        [MaxLength(30, ErrorMessage = "The street should have maximum 30 characters")]
        [MinLength(3, ErrorMessage = "The street should have at least 3 characters.")]
        [RegularExpression(@"^[\p{L}\p{M}' \.\-]+$", ErrorMessage = "Street must be properly formatted.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The city is required")]
        [MaxLength(30, ErrorMessage = "The city should have maximum 30 characters")]
        [MinLength(3, ErrorMessage = "The city should have at least 3 characters.")]
        [RegularExpression(@"^[\p{L}\p{M}' \.\-]+$", ErrorMessage = "City name must be properly formatted.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The postal code is required")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "The house number is required")]
        public string HouseNumber { get; set; }

        public string? LocalNumber { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
