﻿using Clinic.Data.Models;

namespace Clinic.Areas.Identity.Data
{
    public class LabTechnician : ApplicationUser
    {
        public List<LaboratoryExamination>? LaboratoryExaminations { get; set; }
    }
}
