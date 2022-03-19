using Clinic.Data.Models;

namespace Clinic.Areas.Identity.Data
{
    public class Doctor : ApplicationUser
    {
        public long PermissionNumber { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}
