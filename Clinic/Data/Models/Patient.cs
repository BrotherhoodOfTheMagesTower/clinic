using Clinic.Areas.Identity.Data;

namespace Clinic.Data.Models
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? Pesel { get; set; }
        public DateTime? BirthDate { get; set; }
        public long? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public Address? Address { get; set; }
    }
}
