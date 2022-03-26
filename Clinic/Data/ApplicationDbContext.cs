using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinic.Areas.Identity.Data;
using Clinic.Data.Models;

namespace Clinic.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Administrator> Administrator { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<LabManager> LabManager { get; set; }
    public DbSet<LabTechnician> LabTechnician { get; set; }
    public DbSet<Registrar> Registrar { get; set; }
    public DbSet<Appointment> Appointment { get; set; }
    public DbSet<GlossaryDictionary> GlossaryDictionary { get; set; }
    public DbSet<LaboratoryExamination> LaboratoryExamination { get; set; }
    public DbSet<PhysicalExamination> PhysicalExamination { get; set; }
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Address> Address { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<GlossaryDictionary>().HasKey(k => k.Code);

        builder.Entity<Appointment>().HasOne(p => p.Patient).WithMany(p => p.Appointments);
        builder.Entity<Appointment>().HasOne(p => p.Registrar).WithMany(p => p.Appointments);
        builder.Entity<Appointment>().HasOne(p => p.Doctor).WithMany(p => p.Appointments);

        builder.Entity<LaboratoryExamination>().HasOne(p => p.Appointment).WithMany(p => p.LaboratoryExaminations);
        builder.Entity<LaboratoryExamination>().HasOne(p => p.GlossaryDictionary).WithMany(p => p.LaboratoryExaminations);
        builder.Entity<LaboratoryExamination>().HasOne(p => p.LabTechnician).WithMany(p => p.LaboratoryExaminations);
        builder.Entity<LaboratoryExamination>().HasOne(p => p.LabManager).WithMany(p => p.LaboratoryExaminations);

        builder.Entity<PhysicalExamination>().HasOne(p => p.Appointment).WithMany(p => p.PhysicalExaminations);
        builder.Entity<PhysicalExamination>().HasOne(p => p.GlossaryDictionary).WithMany(p => p.PhysicalExaminations);
        builder.Entity<Patient>().HasOne(p => p.Address).WithMany(p => p.Patients);
    }
}
