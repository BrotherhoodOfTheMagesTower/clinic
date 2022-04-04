using Clinic.Data;
using Clinic.Data.Models;

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
    }
}

