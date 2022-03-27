using Clinic.Areas.Identity.Data;
using Clinic.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data
{
    public static class DefaultRolesAndUsersSeed
    {
        public static async Task<List<Tuple<ApplicationUser, string>>> SeedUsersAsync(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var usersWithParticularRole = new List<Tuple<ApplicationUser, string>> { };

            if (!context!.Administrators.Any())
            {
                var administrator = new Administrator
                {
                    FirstName = "Administrator_FN",
                    LastName = "Administrator_LN",
                    User = new ApplicationUser
                    {
                        Email = "admin@admin.com",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        UserName = "admin@admin.com",
                        NormalizedUserName = "ADMIN@ADMIN.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                administrator.User.HashPassword("Admin123!");
                usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(administrator.User, Roles.Administrator));
                context!.Administrators.Add(administrator);
            }

            if (!context.Doctors.Any())
            {
                var doctor = new Doctor
                {
                    FirstName = "Doctor_FN",
                    LastName = "Doctor_LN",
                    PermissionNumber = 1,
                    User = new ApplicationUser
                    {
                        Email = "doctor@doctor.com",
                        NormalizedEmail = "DOCTOR@DOCTOR.COM",
                        UserName = "doctor@doctor.com",
                        NormalizedUserName = "DOCTOR@DOCTOR.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(doctor.User, Roles.Doctor));
                doctor.User.HashPassword();
                context!.Doctors.Add(doctor);
            }

            if (!context.Registrars.Any())
            {
                var registrar = new Registrar
                {
                    FirstName = "Registrar_FN",
                    LastName = "Registrar_LN",
                    User = new ApplicationUser
                    {
                        Email = "registrar@registrar.com",
                        NormalizedEmail = "REGISTRAR@REGISTRAR.COM",
                        UserName = "registrar@registrar.com",
                        NormalizedUserName = "REGISTRAR@REGISTRAR.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(registrar.User, Roles.Registrar)); ;
                registrar.User.HashPassword();
                context!.Registrars.Add(registrar);
            }

            if (!context.LabTechnicians.Any())
            {
                var labTechnician = new LabTechnician
                {
                    FirstName = "LabTechnician_FN",
                    LastName = "LabTechnician_LN",
                    User = new ApplicationUser
                    {
                        Email = "labtechnician@labtechnician.com",
                        NormalizedEmail = "LABTECHNICIAN@LABTECHNICIAN.COM",
                        UserName = "labtechnician@labtechnician.com",
                        NormalizedUserName = "LABTECHNICIAN@LABTECHNICIAN.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(labTechnician.User, Roles.LabTechnician));
                labTechnician.User.HashPassword();
                context!.LabTechnicians.Add(labTechnician);
            }

            if (!context.LabManagers.Any())
            {
                var labManager = new LabManager
                {
                    FirstName = "LabManager_FN",
                    LastName = "LabManager_LN",
                    User = new ApplicationUser
                    {
                        Email = "labmanager@labmanager.com",
                        NormalizedEmail = "LABMANAGER@LABMANAGER.COM",
                        UserName = "labmanager@labmanager.com",
                        NormalizedUserName = "LABMANAGER@LABMANAGER.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(labManager.User, Roles.LabManager));
                labManager.User.HashPassword();
                context!.LabManagers.Add(labManager);
            }

            context!.SaveChanges();

            return usersWithParticularRole;
        }

        public static async Task SeedRolesAsync(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            string[] roles = new string[] { Roles.Administrator, Roles.Doctor, Roles.Registrar, Roles.LabTechnician, Roles.LabManager };

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore, null, null, null, null);
            foreach (var role in roles)
            {
                if (!context!.Roles.Any(r => r.Name == role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            context!.SaveChanges();
        }

        public static async Task AssignRoles(this IServiceProvider serviceProvider, List<Tuple<ApplicationUser, string>> users)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            UserManager<ApplicationUser>? _userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            foreach (var user in users)
            {
                var usr = await _userManager!.FindByEmailAsync(user.Item1.Email);

                if (!await _userManager.IsInRoleAsync(usr, user.Item2))
                    await _userManager.AddToRoleAsync(usr, user.Item2);
            }

            context!.SaveChanges();
        }

        private static void HashPassword(this ApplicationUser user, string psswd = "Password123!")
        {
            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user, psswd);
            user.PasswordHash = hashed;
        }
    }
}
