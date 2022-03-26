using Clinic.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class Registrar : ApplicationUser
    {
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
