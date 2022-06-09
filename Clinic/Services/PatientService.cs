using Clinic.Data;
using Clinic.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class PatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Patient patient)
        {
            if (patient.Pesel != null)
            {
                var obj = GetPatientByPesel(patient.Pesel);
                if (obj != null)
                    return false;
            }
            var guid = Guid.NewGuid();
            patient.Id = guid;
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return true;
        }

        private Patient? GetPatientByPesel(string pesel)
            => _context.Patients.Where(p => p.Pesel == pesel).FirstOrDefault();

        public Patient? GetById(Guid id)
        {
            return _context.Patients
                .Include(a => a.Address)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Patient> GetAllPatients()
            => _context.Patients.ToList();

        public List<Patient>? SearchPatientByPattern(string pattern)
        {
            List<Patient>? patientList = null;
            string[] words = pattern.Split(' ');
            foreach (var word in words)
            {
                List<Patient> tmp = _context.Patients.Where((p => p.FirstName.Contains(word) || p.LastName.Contains(word))).ToList();
                if (patientList == null)
                    patientList = tmp;
                else
                    patientList.AddRange(tmp);
            }

            return patientList;
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public Guid GetPatientAddressId(Guid id)
            => _context.Patients.FirstOrDefault(p => p.Id.Equals(id))!.Id;
    }
}
