using Clinic.Areas.Identity.Data;
using Clinic.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class DoctorService : IUserRepository<Doctor>
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Activate(Doctor tUser)
        {
            tUser.IsActive = true;
            Update(tUser);
        }

        public void Add(Doctor tUser)
        {
            if (tUser == null) return;
            _context.Doctors.Add(tUser);
            _context.SaveChanges();
        }

        public void Disable(Doctor tUser)
        {
            tUser.IsActive = false;
            Update(tUser);
        }

        public Doctor? GetById(string id)
            => _context.Doctors.FirstOrDefault(x => x.Id == id);

        public bool IsUserActive(Doctor tUser)
            => tUser.IsActive;

        public void Update(Doctor tUser)
        {
            if (tUser == null) return;
            _context.Doctors.Update(tUser);
            _context.SaveChanges();
        }

        public List<Doctor> GetAllDoctors()
           => _context.Doctors.ToList();

        public async Task<List<Doctor>> GetAllDoctorsAsync()
         => await _context.Doctors
                .ToListAsync();
        public Doctor? GetDoctorByEmail(string? email)
            => email != null
            ? _context.Doctors.Where(x => x.User.Email == email).FirstOrDefault()
            : null;
    }
}