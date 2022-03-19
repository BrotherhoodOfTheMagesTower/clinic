using Clinic.Data.Models;

namespace Clinic.Areas.Identity.Data
{
    public class LabManager : ApplicationUser
    {
        public List<LaboratoryExamination>? LaboratoryExaminations { get; set; }
    }
}
