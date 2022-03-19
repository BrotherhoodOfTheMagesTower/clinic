namespace Clinic.Data.Models
{
    public class GlossaryDictionary
    {
        public GlossaryCode Code { get; set; }
        public GlossaryType Type { get; set; }
        public string Name { get; set; }
        public List<PhysicalExamination>? PhysicalExaminations { get; set; }
        public List<LaboratoryExamination>? LaboratoryExaminations { get; set; }
    }
}
