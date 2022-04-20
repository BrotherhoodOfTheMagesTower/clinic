using Clinic.Data;
using Clinic.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class LaboratoryExaminationService
    {
        private readonly ApplicationDbContext _context;

        public LaboratoryExaminationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(LaboratoryExamination laboratoryExaminations)
        {
            if (laboratoryExaminations == null) return;
            _context.LaboratoryExaminations.Add(laboratoryExaminations);
            _context.SaveChanges();
        }

        public LaboratoryExamination? GetById(Guid id)
            => _context.LaboratoryExaminations.FirstOrDefault(l => l.Id == id);

        public async Task<LaboratoryExamination?> GetByIdAsync(Guid id)
           => await _context.LaboratoryExaminations
            .Include(l => l.LabTechnician)
            .Include(g => g.GlossaryDictionary)
            .Include(l => l.LabManager)
            .Include(a => a.Appointment)
            .FirstOrDefaultAsync(l => l.Id == id);

        public void Update(LaboratoryExamination laboratoryExamination)
        {
            if (laboratoryExamination == null) return;
            _context.LaboratoryExaminations.Update(laboratoryExamination);
            _context.SaveChanges();
        }

        public async Task<List<LaboratoryExamination>> GetAllLabExaminationsAsync()
         => await _context.LaboratoryExaminations
            .Include(g => g.GlossaryDictionary)
            .Include(l => l.LabManager)
            .Include(a => a.Appointment)
            .Include(l => l.LabTechnician)
            .ToListAsync();

        public async Task<List<LaboratoryExamination>> GetAllLabExaminationsForGivenPatientAsync(Patient patient)
        => await _context.LaboratoryExaminations
           .Include(g => g.GlossaryDictionary)
           .Include(l => l.LabManager)
           .Include(a => a.Appointment)
           .Include(a => a.Appointment.Patient)
           .Include(l => l.LabTechnician)
           .Where(p => p.Appointment.Patient == patient)
           .ToListAsync();

        public async Task<List<LaboratoryExamination>> GetLaboratoryExaminationsAsync(Appointment appointment)
        => await _context.LaboratoryExaminations
            .Include(l => l.LabManager)
            .Include(l => l.LabTechnician)
            .Include(g => g.GlossaryDictionary)
            .Include(a => a.Appointment)
            .Where(a => a.Appointment == appointment)
            .ToListAsync();
    }
}