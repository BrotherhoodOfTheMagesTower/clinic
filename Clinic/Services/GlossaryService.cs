using Clinic.Data;
using Clinic.Data.Models;

namespace Clinic.Services
{
    public class GlossaryService
    {
        private readonly ApplicationDbContext _context;

        public GlossaryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(GlossaryDictionary glossaryDictionary)
        {
            _context.GlossaryDictionaries.Add(glossaryDictionary);
            _context.SaveChanges();
        }

        public GlossaryDictionary? GetByCode(GlossaryCode glossaryCode)
            => _context.GlossaryDictionaries.FirstOrDefault(g => g.Code == glossaryCode);

        public void Update(GlossaryDictionary glossaryDictionary)
        {
            _context.GlossaryDictionaries.Update(glossaryDictionary);
            _context.SaveChanges();
        }

        public List<GlossaryDictionary> GetAllDictionaries()
           => _context.GlossaryDictionaries.ToList();
    }
}