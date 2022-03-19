using Clinic.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class LabTechnician
    {
        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public List<LaboratoryExamination>? LaboratoryExaminations { get; set; }
        public ApplicationUser User { get; set; }
    }
}
