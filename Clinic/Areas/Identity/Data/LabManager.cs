using Clinic.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class LabManager
    {
        [MaxLength(30, ErrorMessage = "The first name should have maximum 30 characters")]
        [MinLength(3, ErrorMessage = "The first name should have at least 3 characters.")]
        [RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "First name must be properly formatted.")]
        public string? FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "The last name should have maximum 30 characters")]
        [MinLength(3, ErrorMessage = "The last name should have at least 3 characters.")]
        [RegularExpression("^((?!^Last Name$)[a-zA-Z '])+$", ErrorMessage = "Last name must be properly formatted.")]
        public string? LastName { get; set; }

        public ICollection<LaboratoryExamination>? LaboratoryExaminations { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(User))]
        public string Id { get; set; }

        public ApplicationUser User { get; set; }
    }
}
