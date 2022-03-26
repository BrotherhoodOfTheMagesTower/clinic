using Clinic.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class LabTechnician : ApplicationUser
    {
        public ICollection<LaboratoryExamination>? LaboratoryExaminations { get; set; }
    }
}
