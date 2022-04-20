using Clinic.Data;
using Clinic.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class PhysicalExaminationService
    {
        private readonly ApplicationDbContext _context;

        public PhysicalExaminationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(PhysicalExamination physicalExamination)
        {
            if (physicalExamination == null) return;
            _context.PhysicalExaminations.Add(physicalExamination);
            _context.SaveChanges();
        }

        public PhysicalExamination? GetById(Guid id)
            => _context.PhysicalExaminations.FirstOrDefault(l => l.Id == id);

        public async Task<PhysicalExamination?> GetByIdAsync(Guid id)
           => await _context.PhysicalExaminations
            .Include(l => l.GlossaryDictionary)
            .Include(l => l.Appointment)
            .FirstOrDefaultAsync(l => l.Id == id);

        public void Update(PhysicalExamination physicalExamination)
        {
            if (physicalExamination == null) return;
            _context.PhysicalExaminations.Update(physicalExamination);
            _context.SaveChanges();
        }

        public List<PhysicalExamination> GetAllExaminations()
           => _context.PhysicalExaminations.ToList();

        public async Task<List<PhysicalExamination>> GetAllExaminationsAsync()
       => await _context.PhysicalExaminations
          .Include(g => g.GlossaryDictionary)
          .Include(a => a.Appointment)
          .ToListAsync();

        public async Task<List<PhysicalExamination>> GetAllExaminationsForGivenPatientAsync(Patient patient)
       => await _context.PhysicalExaminations
         .Include(g => g.GlossaryDictionary)
         .Include(a => a.Appointment)
         .Include(a => a.Appointment.Patient)
         .Where(p => p.Appointment.Patient == patient)
         .ToListAsync();

        public async Task<List<PhysicalExamination>> GetPhysicalExaminationsAsync(Appointment appointment)
          => await _context.PhysicalExaminations
              .Include(l => l.GlossaryDictionary)
              .Include(a => a.Appointment)
              .Where(a => a.Appointment == appointment)
              .ToListAsync();
    }
}