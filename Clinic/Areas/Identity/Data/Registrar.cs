using Clinic.Data.Models;

namespace Clinic.Areas.Identity.Data
{
    public class Registrar : ApplicationUser
    {
        public List<Appointment>? Appointments { get; set; }
    }
}
