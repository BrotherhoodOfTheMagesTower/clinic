using Clinic.Data;
using Clinic.Data.Models;

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
            _context.LaboratoryExaminations.Add(laboratoryExaminations);
            _context.SaveChanges();
        }

        public LaboratoryExamination? GetById(Guid id)
            => _context.LaboratoryExaminations.FirstOrDefault(l => l.Id == id);

        public void Update(LaboratoryExamination laboratoryExamination)
        {
            _context.LaboratoryExaminations.Update(laboratoryExamination);
            _context.SaveChanges();
        }

        public List<LaboratoryExamination> GetAllLabExaminations()
           => _context.LaboratoryExaminations.ToList();
    }
}
