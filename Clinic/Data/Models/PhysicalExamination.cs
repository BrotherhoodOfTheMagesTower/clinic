using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Data.Models
{
    public class PhysicalExamination
    {
        public Guid Id { get; set; }
        public string Result { get; set; }
        public Appointment Appointment { get; set; }
        public GlossaryDictionary GlossaryDictionary { get; set; }
    }
}
