using Clinic.Areas.Identity.Data;
using Clinic.Data.Enums;

namespace Clinic.Data.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Pesel { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public Address? Address { get; set; }
    }
}
