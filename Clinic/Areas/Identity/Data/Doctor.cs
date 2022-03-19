using Clinic.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class Doctor
    {
        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public ApplicationUser User { get; set; }
        public long? PermissionNumber { get; set; }
    }
}
