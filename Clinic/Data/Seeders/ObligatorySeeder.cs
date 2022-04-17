using Clinic.Areas.Identity.Data;
using Clinic.Constants;
using Clinic.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Clinic.Data.Seeders
{
    public static class ObligatorySeeder
    {
        public static async Task SeedRequiredData(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            //Seed default roles
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

            //Seed Administrator account
            if (!context!.Administrators.Any())
            {
                var administrator = new Administrator
                {
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
                context!.Administrators.Add(administrator);
                context!.SaveChanges();

                UserManager<ApplicationUser> _userManager = serviceProvider.GetService<UserManager<ApplicationUser>>()!;
                if(!await _userManager.IsInRoleAsync(administrator.User, Roles.Administrator))
                    await _userManager!.AddToRoleAsync(administrator.User, Roles.Administrator);
            }

            //Seed default Glossary
            if(!context!.GlossaryDictionaries.Any())
            {
                var blood = new GlossaryDictionary { Code = GlossaryCode.LAB_BLOOD, Name = "Blood examination", Type = GlossaryType.LABORATORY };
                var covid = new GlossaryDictionary { Code = GlossaryCode.LAB_COVID, Name = "Covid examination", Type = GlossaryType.LABORATORY };
                var urine = new GlossaryDictionary { Code = GlossaryCode.LAB_URINE, Name = "Urine examination", Type = GlossaryType.LABORATORY };
                var ear = new GlossaryDictionary { Code = GlossaryCode.PHY_EAR, Name = "Ear examination", Type = GlossaryType.PHYSICAL };
                var throat = new GlossaryDictionary { Code = GlossaryCode.PHY_THROAT, Name = "Throat examination", Type = GlossaryType.PHYSICAL };
                var usg = new GlossaryDictionary { Code = GlossaryCode.PHY_USG, Name = "USG examination", Type = GlossaryType.PHYSICAL };
                context.GlossaryDictionaries.Add(blood);
                context.GlossaryDictionaries.Add(covid);
                context.GlossaryDictionaries.Add(urine);
                context.GlossaryDictionaries.Add(ear);
                context.GlossaryDictionaries.Add(throat);
                context.GlossaryDictionaries.Add(usg);
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
