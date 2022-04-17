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
            _context.PhysicalExaminations.Add(physicalExamination);
            _context.SaveChanges();
        }

        public PhysicalExamination? GetById(Guid id)
            => _context.PhysicalExaminations.FirstOrDefault(l => l.Id == id);

        public void Update(PhysicalExamination physicalExamination)
        {
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

        public async Task<List<PhysicalExamination>> GetAllExaminationsForGivenPatientAsync(Guid id)
       => await _context.PhysicalExaminations
         .Include(g => g.GlossaryDictionary)
         .Include(a => a.Appointment)
         .Where(p => p.Id == id)
         .ToListAsync();
    }

}

