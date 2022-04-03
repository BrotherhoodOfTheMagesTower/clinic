namespace Clinic.Data.Models
{
    public class GlossaryDictionary
    {
        public GlossaryCode Code { get; set; }
        public GlossaryType Type { get; set; }
        public string Name { get; set; }
        public ICollection<PhysicalExamination>? PhysicalExaminations { get; set; }
        public ICollection<LaboratoryExamination>? LaboratoryExaminations { get; set; }
    }
}
