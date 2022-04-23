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
            Update(tUser);
        }

        public void Add(Registrar tUser)
        {
            _context.Registrars.Add(tUser);
            _context.SaveChanges();
        }

        public void Disable(Registrar tUser)
        {
            tUser.IsActive = false;
            Update(tUser);
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
            _context.SaveChanges();
        }

        public List<Registrar> GetAllRegistrars()
           => _context.Registrars.ToList();

        public Registrar? GetRegistrarByEmail(string email)
            => _context.Registrars.Where(x => x.User.Email == email).FirstOrDefault();
    }
}
