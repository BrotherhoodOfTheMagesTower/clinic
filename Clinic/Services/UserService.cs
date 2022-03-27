using Clinic.Areas.Identity.Data;
using Clinic.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
            => await _context.Users.ToListAsync();

        public List<string> GetRolesForUser(string userId)
        {
            var roleIds = _context.UserRoles.Where(x => x.UserId == userId).Select(r => r.RoleId).ToList();
            var roleNames = new List<string>();
            foreach (var roleId in roleIds)
                roleNames.AddRange(_context.Roles.Where(x => x.Id == roleId).Select(r => r.Name).ToList());

            return roleNames;
        }

        public async Task<string> GetUserName(string userId)
            => (await _context.Users.FirstOrDefaultAsync(x => x.Id == userId))!.UserName;

        public List<IdentityRole> GetAllRoles()
            => _context.Roles.ToList();

        public ApplicationUser GetUserByIdAsync(string userId)
            => _context.Users.Where(x => x.Id == userId).FirstOrDefault();

        //public async Task SetFirstAndLastNameForSpecificUser(string userId, string firstName, string lastName)
        //{
        //    _context.Users.Where(x => x.Id == userId).First().FirstName = firstName;
        //    _context.Users.Where(x => x.Id == userId).First().LastName = lastName;

        //    await _context.SaveChangesAsync();
        //}
    }
}
