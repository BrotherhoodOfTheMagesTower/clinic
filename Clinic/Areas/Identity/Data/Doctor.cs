using Clinic.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class Doctor : ApplicationUser
    {
        public ICollection<Appointment>? Appointments { get; set; }
        public long? PermissionNumber { get; set; }
    }
}
