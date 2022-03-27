using Clinic.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class LabManager
    {
        [StringLength(255, ErrorMessage = "The first name field should have maximum 255 characters")]
        public string? FirstName { get; set; }

        [StringLength(255, ErrorMessage = "The first name field should have maximum 255 characters")]
        public string? LastName { get; set; }

        public ICollection<LaboratoryExamination>? LaboratoryExaminations { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(User))]
        public string Id { get; set; }

        public ApplicationUser User { get; set; }
    }
}
