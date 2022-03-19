namespace Clinic.Data.Models
{
    public class PhysicalExamination
    {
        public Guid PhysicalExaminationId { get; set; }
        public string Result { get; set; }
        public Guid AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public GlossaryCode GlossaryDictionaryId { get; set; }
        public virtual GlossaryDictionary GlossaryDictionary { get; set; }
    }
}
