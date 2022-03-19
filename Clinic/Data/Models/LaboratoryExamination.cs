﻿using Clinic.Areas.Identity.Data;

namespace Clinic.Data.Models
{
    public class LaboratoryExamination
    {
        public Guid LaboratoryExaminationId { get; set; }
        public string? DoctorsNotes { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Result { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string? ManagerNotes { get; set; }
        public DateTime ApprovalDate { get; set; }
        public Status Status { get; set; }
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public GlossaryCode GlossaryDictionaryId { get; set; }
        public GlossaryDictionary GlossaryDictionary { get; set; }
        public string? LabTechnicianId { get; set; }
        public LabTechnician? LabTechnician { get; set; }
        public string? LabManagerId { get; set; }
        public LabManager? LabManager { get; set; }
    }
}
