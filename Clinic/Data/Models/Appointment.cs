using Clinic.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Data.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime RegisteredTo { get; set; }
        public Doctor Doctor { get; set; }
        public Registrar Registrar { get; set; }
        public Patient Patient { get; set; }

        public ICollection<LaboratoryExamination>? LaboratoryExaminations { get; set; }
        public ICollection<PhysicalExamination>? PhysicalExaminations { get; set; }
    }
}
