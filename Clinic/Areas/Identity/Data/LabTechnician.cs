using Clinic.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class LabTechnician
    {
        [MaxLength(255, ErrorMessage = "The first name should have maximum 255 characters")]
        [MinLength(3, ErrorMessage = "The first name should have at least 3 characters.")]
        public string? FirstName { get; set; }

        [MaxLength(255, ErrorMessage = "The last name should have maximum 255 characters")]
        [MinLength(3, ErrorMessage = "The last name should have at least 3 characters.")]
        public string? LastName { get; set; }

        public ICollection<LaboratoryExamination>? LaboratoryExaminations { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(User))]
        public string Id { get; set; }

        public ApplicationUser User { get; set; }
    }
}
