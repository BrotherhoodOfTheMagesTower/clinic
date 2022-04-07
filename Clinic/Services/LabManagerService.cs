using Clinic.Areas.Identity.Data;
using Clinic.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class LabManagerService : IUserRepository<LabManager>
    {
        private readonly ApplicationDbContext _context;

        public LabManagerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Activate(LabManager tUser)
        {
            tUser.IsActive = true;
            Update(tUser);
        }

        public void Add(LabManager tUser)
        {
            _context.LabManagers.Add(tUser);
            _context.SaveChanges();

        }

        public void Disable(LabManager tUser)
        {
            tUser.IsActive = false;
            Update(tUser);
        }

        public LabManager? GetById(string id)
            => _context.LabManagers.FirstOrDefault(x => x.Id == id);

        public bool IsUserActive(LabManager tUser)
            => tUser.IsActive;

        public void Update(LabManager tUser)
        {
            _context.LabManagers.Update(tUser);
            _context.SaveChanges();
        }

        public async Task<List<LabManager>> GetAllLabManagersAsync()
        {
            return await _context.LabManagers.ToListAsync();
        }
    }
}
