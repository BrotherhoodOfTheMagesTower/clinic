using Clinic.Areas.Identity.Data;
using Clinic.Constants;
using Clinic.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserService(ApplicationDbContext context, IServiceScopeFactory serviceScopeFactory)
        {
            _context = context;
            _serviceScopeFactory = serviceScopeFactory;
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

        public string GetRolesForUserInOneStringSplittedByAComa(string userId)
        {
            var roles = GetRolesForUser(userId);

            if (roles != null)
            {
                if (roles.Count == 1)
                    return roles.First();
                else if (roles.Count != 0)
                    return string.Join(", ", roles);
            }

            return "";
        }

        public async Task<string> GetUserName(string userId)
            => (await _context.Users.FirstOrDefaultAsync(x => x.Id == userId))!.UserName;

        public List<IdentityRole> GetAllRoles()
            => _context.Roles.ToList();

        public ApplicationUser? GetUserById(string userId)
            => _context.Users.Where(x => x.Id == userId).FirstOrDefault();

        public ApplicationUser? GetUserByEmail(string email)
            => _context.Users.Where(x => x.Email == email).FirstOrDefault();

        public Tuple<string?, string?> GetFirstAndLastNameForSpecificUser(string userId)
        {
            var roles = GetRolesForUser(userId);

            if (roles is not null)
            {
                foreach (var role in roles)
                {
                    switch (role)
                    {
                        case Roles.Doctor:
                            var doc = _context.Doctors.Where(x => x.Id == userId).FirstOrDefault();
                            if (doc is not null)
                            {
                                return Tuple.Create(doc.FirstName, doc.LastName);
                            }
                            else continue;

                        case Roles.Registrar:
                            var reg = _context.Registrars.Where(x => x.Id == userId).FirstOrDefault();
                            if (reg is not null)
                            {
                                return Tuple.Create(reg.FirstName, reg.LastName);
                            }
                            else continue;
                        case Roles.LabTechnician:
                            var tech = _context.LabTechnicians.Where(x => x.Id == userId).FirstOrDefault();
                            if (tech is not null)
                            {
                                return Tuple.Create(tech.FirstName, tech.LastName);
                            }
                            else continue;
                        case Roles.LabManager:
                            var man = _context.LabManagers.Where(x => x.Id == userId).FirstOrDefault();
                            if (man is not null)
                            {
                                return Tuple.Create(man.FirstName, man.LastName);
                            }
                            else continue;
                    }
                }
                return new Tuple<string?, string?>(null, null);
            }
            return new Tuple<string?, string?>(null, null);
        }

        public async Task<bool> SetFirstAndLastNameForSpecificUserAsync(string userId, string firstName, string lastName)
        {
            var roles = GetRolesForUser(userId);

            if(roles is not null)
            {
                foreach (var role in roles)
                {
                    switch (role)
                    {
                        case Roles.Doctor:
                            var doc = _context.Doctors.Where(x => x.Id == userId).FirstOrDefault();
                            if (doc is not null)
                            {
                                doc.FirstName = firstName;
                                doc.LastName = lastName;
                                await _context.SaveChangesAsync();
                                return true;
                            }
                            else continue;

                        case Roles.Registrar:
                            var reg = _context.Registrars.Where(x => x.Id == userId).FirstOrDefault();
                            if (reg is not null)
                            {
                                reg.FirstName = firstName;
                                reg.LastName = lastName;
                                await _context.SaveChangesAsync();
                                return true;
                            }
                            else continue;
                        case Roles.LabTechnician:
                            var tech = _context.LabTechnicians.Where(x => x.Id == userId).FirstOrDefault();
                            if (tech is not null)
                            {
                                tech.FirstName = firstName;
                                tech.LastName = lastName;
                                await _context.SaveChangesAsync();
                                return true;
                            }
                            else continue;
                        case Roles.LabManager:
                            var man = _context.LabManagers.Where(x => x.Id == userId).FirstOrDefault();
                            if (man is not null)
                            {
                                man.FirstName = firstName;
                                man.LastName = lastName;
                                await _context.SaveChangesAsync();
                                return true;
                            }
                            else continue;
                    }
                }

                return false;
            }

            return false;
        }

        public async Task<bool> CreateNewDoctorUser(string? firstName, string? lastName, string email, string password, long permissionNumber)
        {
            var obj = GetUserByEmail(email);
            if (obj is not null)
                return false;

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var psswd = new PasswordHasher<ApplicationUser>();
                var store = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(store, null, psswd, null, null, null, null, null, null);
                var id = Guid.NewGuid();
                var user = new ApplicationUser
                {
                    Id = id.ToString(),
                    Email = email,
                    UserName = email,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var hashed = psswd.HashPassword(user, password);
                user.PasswordHash = hashed;
                await userManager.CreateAsync(user);

                var doctor = new Doctor()
                {
                    Id = id.ToString(),
                    FirstName = firstName,
                    LastName = lastName,
                    PermissionNumber = permissionNumber,
                    User = user
                };
                db!.Doctors.Add(doctor);
                await userManager.AddToRoleAsync(doctor.User, Roles.Doctor);
                await db.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> CreateNewRegistrarUser(string? firstName, string? lastName, string email, string password)
        {
            var obj = GetUserByEmail(email);
            if (obj is not null)
                return false;

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var psswd = new PasswordHasher<ApplicationUser>();
                var store = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(store, null, psswd, null, null, null, null, null, null);
                var id = Guid.NewGuid();
                var user = new ApplicationUser
                {
                    Id = id.ToString(),
                    Email = email,
                    UserName = email,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var hashed = psswd.HashPassword(user, password);
                user.PasswordHash = hashed;
                await userManager.CreateAsync(user);

                var registrar = new Registrar()
                {
                    Id = id.ToString(),
                    FirstName = firstName,
                    LastName = lastName,
                    User = user
                };
                db!.Registrars.Add(registrar);
                await userManager.AddToRoleAsync(registrar.User, Roles.Registrar);
                await db.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> CreateNewLabTechnicianUser(string? firstName, string? lastName, string email, string password)
        {
            var obj = GetUserByEmail(email);
            if (obj is not null)
                return false;

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var psswd = new PasswordHasher<ApplicationUser>();
                var store = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(store, null, psswd, null, null, null, null, null, null);
                var id = Guid.NewGuid();
                var user = new ApplicationUser
                {
                    Id = id.ToString(),
                    Email = email,
                    UserName = email,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var hashed = psswd.HashPassword(user, password);
                user.PasswordHash = hashed;
                await userManager.CreateAsync(user);

                var labTechnician = new LabTechnician
                {
                    Id = id.ToString(),
                    FirstName = firstName,
                    LastName = lastName,
                    User = user
                };
                db!.LabTechnicians.Add(labTechnician);
                await userManager.AddToRoleAsync(labTechnician.User, Roles.LabTechnician);
                await db.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> CreateNewLabManagerUser(string? firstName, string? lastName, string email, string password)
        {
            var obj = GetUserByEmail(email);
            if (obj is not null)
                return false;

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var psswd = new PasswordHasher<ApplicationUser>();
                var store = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(store, null, psswd, null, null, null, null, null, null);
                var id = Guid.NewGuid();
                var user = new ApplicationUser
                {
                    Id = id.ToString(),
                    Email = email,
                    UserName = email,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var hashed = psswd.HashPassword(user, password);
                user.PasswordHash = hashed;
                await userManager.CreateAsync(user);

                var labManager = new LabManager
                {
                    Id = id.ToString(),
                    FirstName = firstName,
                    LastName = lastName,
                    User = user
                };
                db!.LabManagers.Add(labManager);
                await userManager.AddToRoleAsync(labManager.User, Roles.LabManager);
                await db.SaveChangesAsync();

                return true;
            }
        }
    }
}
