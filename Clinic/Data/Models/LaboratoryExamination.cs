using Clinic.Areas.Identity.Data;

namespace Clinic.Data.Models
{
    public class LaboratoryExamination
    {
        public Guid Id { get; set; }
        public string? DoctorsNotes { get; set; }
        public DateTime OrderedAt { get; set; }
        public string? Result { get; set; }
        public DateTime? ExecutedOrCancelledAt { get; set; }
        public string? ManagerNotes { get; set; }
        public DateTime? ApprovedOrCancelledAt { get; set; }
        public AppointmentStatus Status { get; set; }
        public Appointment Appointment { get; set; }
        public GlossaryDictionary GlossaryDictionary { get; set; }
        public LabTechnician? LabTechnician { get; set; }
        public LabManager? LabManager { get; set; }
    }
}
