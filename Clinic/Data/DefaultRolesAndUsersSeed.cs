using Clinic.Areas.Identity.Data;
using Clinic.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data
{
    public static class DefaultRolesAndUsersSeed
    {
        public static async Task<ApplicationUser[]> SeedUsersAsync(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var users = new List<ApplicationUser> { };

            if (!context!.Administrators.Any() && context.Users.Where(x => x.FirstName == "Administrator").ToList().Count == 0)
            {
                var administrator = new Administrator
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Administrator",
                        LastName = "AdministratorL",
                        Email = "admin@admin.com",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        UserName = "admin@admin.com",
                        NormalizedUserName = "ADMIN@ADMIN.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                administrator.User.HashPassword();
                users.Add(administrator.User);
                context!.Administrators.Add(administrator);
            }

            if (!context.Doctors.Any() && context.Users.Where(x => x.FirstName == "Doctor").ToList().Count == 0)
            {
                var doctor = new Doctor
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Doctor",
                        LastName = "DoctorL",
                        Email = "doctor@doctor.com",
                        NormalizedEmail = "DOCTOR@DOCTOR.COM",
                        UserName = "doctor@doctor.com",
                        NormalizedUserName = "DOCTOR@DOCTOR.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                users.Add(doctor.User);
                doctor.User.HashPassword();
                context!.Doctors.Add(doctor);
            }

            if (!context.Registrars.Any() && context.Users.Where(x => x.FirstName == "Registrar").ToList().Count == 0)
            {
                var registrar = new Registrar
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Registrar",
                        LastName = "RegistrarL",
                        Email = "registrar@registrar.com",
                        NormalizedEmail = "REGISTRAR@REGISTRAR.COM",
                        UserName = "registrar@registrar.com",
                        NormalizedUserName = "REGISTRAR@REGISTRAR.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                users.Add(registrar.User);
                registrar.User.HashPassword();
                context!.Registrars.Add(registrar);
            }

            if (!context.LabTechnicians.Any() && context.Users.Where(x => x.FirstName == "Lab Technician").ToList().Count == 0)
            {
                var labTechnician = new LabTechnician
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Lab Technician",
                        LastName = "LabTechnicianL",
                        Email = "labtechnician@labtechnician.com",
                        NormalizedEmail = "LABTECHNICIAN@LABTECHNICIAN.COM",
                        UserName = "labtechnician@labtechnician.com",
                        NormalizedUserName = "LABTECHNICIAN@LABTECHNICIAN.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                users.Add(labTechnician.User);
                labTechnician.User.HashPassword();
                context!.LabTechnicians.Add(labTechnician);
            }

            if (!context.LabManagers.Any() && context.Users.Where(x => x.FirstName == "Lab Manager").ToList().Count == 0)
            {
                var labManager = new LabManager
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Lab Manager",
                        LastName = "LabManagerL",
                        Email = "labmanager@labmanager.com",
                        NormalizedEmail = "LABMANAGER@LABMANAGER.COM",
                        UserName = "labmanager@labmanager.com",
                        NormalizedUserName = "LABMANAGER@LABMANAGER.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                users.Add(labManager.User);
                labManager.User.HashPassword();
                context!.LabManagers.Add(labManager);
            }

            context!.SaveChanges();

            return users.ToArray();
        }

        public static async Task SeedRolesAsync(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            string[] roles = new string[] { Roles.Administrator, Roles.Doctor, Roles.Registrar, Roles.LabTechnician, Roles.LabManager };

            foreach (var role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context!.Roles.Any(r => r.Name == role))
                {
                    var roleManager = new RoleManager<IdentityRole>(roleStore, null, null, null, null);
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            context!.SaveChanges();
        }

        public static async Task AssignRoles(this IServiceProvider serviceProvider, ApplicationUser[] users)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            UserManager<ApplicationUser>? _userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            foreach (var user in users)
            {
                var usr = await _userManager!.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(usr, usr.FirstName);
            }

            context!.SaveChanges();
        }

        private static void HashPassword(this ApplicationUser user)
        {
            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user, "Password123!");
            user.PasswordHash = hashed;
        }
    }
}
