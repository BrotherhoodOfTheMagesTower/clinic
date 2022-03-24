using Clinic.Areas.Identity.Data;

namespace Clinic.Data.Models
{
    public class Appointment
    {
        public Guid AppointmentId { get; set; }
        public string Description { get; set; } //Not null?
        public string? Diagnosis { get; set; } 
        public Status Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string RegistrarId { get; set; }
        public Registrar Registrar { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public List<LaboratoryExamination>? LaboratoryExaminations { get; set; }
        public List<PhysicalExamination>? PhysicalExaminations { get; set; }

    }
}
