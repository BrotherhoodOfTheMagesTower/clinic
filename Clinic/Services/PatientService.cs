﻿using Clinic.Data;
using Clinic.Data.Models;

namespace Clinic.Services
{
    public class PatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Patient patient)
        {
            if (patient != null)
            {
                _context.Patients.Add(patient);
            }
        }
        public Patient GetById(Guid id)
        {
            return _context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public List<Patient> GetAllPatients()
            => _context.Patients.ToList();

        public void Update(Patient patient)
        {
            if (patient != null)
            {
                _context.Patients.Update(patient);
            }
        }
    }
}
