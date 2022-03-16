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

            var users = new ApplicationUser[]
            {
                new ApplicationUser
            {
                FirstName = "Administrator",
                LastName = "AdministratorL",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            },
                new ApplicationUser
            {
                FirstName = "Doctor",
                LastName = "DoctorL",
                Email = "doctor@doctor.com",
                NormalizedEmail = "DOCTOR@DOCTOR.COM",
                UserName = "doctor@doctor.com",
                NormalizedUserName = "DOCTOR@DOCTOR.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            },
                new ApplicationUser
            {
                FirstName = "Registrar",
                LastName = "RegistrarL",
                Email = "registrar@registrar.com",
                NormalizedEmail = "REGISTRAR@REGISTRAR.COM",
                UserName = "registrar@registrar.com",
                NormalizedUserName = "REGISTRAR@REGISTRAR.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            },
                new ApplicationUser
            {
                FirstName = "Lab Technician",
                LastName = "LabTechnicianL",
                Email = "labtechnician@labtechnician.com",
                NormalizedEmail = "LABTECHNICIAN@LABTECHNICIAN.COM",
                UserName = "labtechnician@labtechnician.com",
                NormalizedUserName = "LABTECHNICIAN@LABTECHNICIAN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            },
                new ApplicationUser
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

            var psswd = "Password123!";

            foreach (var user in users)
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, psswd);
                user.PasswordHash = hashed;

                await userManager!.CreateAsync(user, psswd);
            }
            
            context!.SaveChanges();

            return users;
        }

        public static async Task SeedRolesAsync(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            string[] roles = new string[] { Roles.Administrator, Roles.Doctor, Roles.Registrar, Roles.LabTechnician, Roles.LabManager };

            foreach(var role in roles)
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

            foreach(var user in users)
            {
                var usr = await _userManager!.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(usr, usr.FirstName);
            }

            context!.SaveChanges();
        }
    }
}
