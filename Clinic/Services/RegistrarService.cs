using Clinic.Areas.Identity.Data;
using Clinic.Data;

namespace Clinic.Services
{
    public class RegistrarService : IUserRepository<Registrar>
    {
        private readonly ApplicationDbContext _context;

        public RegistrarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Activate(Registrar tUser)
        {
            tUser.IsActive = true;
        }

        public void Add(Registrar tUser)
        {
            _context.Registrars.Add(tUser);
        }

        public void Disable(Registrar tUser)
        {
            tUser.IsActive = false;
        }

        public Registrar GetById(string id)
        {
            return _context.Registrars.FirstOrDefault(r => r.Id == id);
        }

        public bool IsUserActive(Registrar tUser)
        {
            return tUser.IsActive;
        }
         
        public void Update(Registrar tUser)
        {
            _context.Registrars.Update(tUser);
        }
    }
}
