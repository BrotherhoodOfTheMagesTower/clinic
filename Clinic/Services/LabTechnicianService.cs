using Clinic.Areas.Identity.Data;
using Clinic.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class LabTechnicianService : IUserRepository<LabTechnician>
    {
        private readonly ApplicationDbContext _context;

        public LabTechnicianService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Activate(LabTechnician tUser)
        {
            tUser.IsActive = true;
            Update(tUser);
        }

        public void Add(LabTechnician tUser)
        {
            _context.LabTechnicians.Add(tUser);
            _context.SaveChanges();

        }

        public void Disable(LabTechnician tUser)
        {
            tUser.IsActive = false;
            Update(tUser);
        }

        public LabTechnician? GetById(string id)
            => _context.LabTechnicians.FirstOrDefault(x => x.Id == id);

        public bool IsUserActive(LabTechnician tUser)
            => tUser.IsActive;

        public void Update(LabTechnician tUser)
        {
            _context.LabTechnicians.Update(tUser);
            _context.SaveChanges();
        }

        public async Task<List<LabTechnician>> GetAllLabTechniciansAsync()
        {
            return await _context.LabTechnicians.ToListAsync();
        }
    }
}
