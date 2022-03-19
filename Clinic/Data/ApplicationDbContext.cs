using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinic.Areas.Identity.Data;
using Clinic.Data.Models;

namespace Clinic.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<LabManager> LabManagers { get; set; }
    public DbSet<LabTechnician> LabTechnicians { get; set; }
    public DbSet<Registrar> Registrars { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<GlossaryDictionary> GlossaryDictionaries { get; set; }
    public DbSet<LaboratoryExamination> LaboratoryExaminations { get; set; }
    public DbSet<PhysicalExamination> PhysicalExaminations { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<Administrator>().ToTable("Administrators");
        builder.Entity<Doctor>().ToTable("Doctors");
        builder.Entity<LabManager>().ToTable("LabManagers");
        builder.Entity<LabTechnician>().ToTable("LabTechnicians");
        builder.Entity<Registrar>().ToTable("Registrars");

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        builder.Entity<Appointment>().HasOne(p => p.Patient).WithMany(p => p.Appointments).HasForeignKey(f => f.PatientId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Appointment>().HasOne(p => p.Registrar).WithMany(p => p.Appointments).HasForeignKey(f => f.RegistrarId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Appointment>().HasOne(p => p.Doctor).WithMany(p => p.Appointments).HasForeignKey(f => f.DoctorId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<LaboratoryExamination>().HasOne(p => p.Appointment).WithMany(p => p.LaboratoryExaminations).HasForeignKey(f => f.AppointmentId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<LaboratoryExamination>().HasOne(p => p.GlossaryDictionary).WithMany(p => p.LaboratoryExaminations).HasForeignKey(f => f.GlossaryDictionaryId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<LaboratoryExamination>().HasOne(p => p.LabTechnician).WithMany(p => p.LaboratoryExaminations).HasForeignKey(f => f.LabTechnicianId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<LaboratoryExamination>().HasOne(p => p.LabManager).WithMany(p => p.LaboratoryExaminations).HasForeignKey(f => f.LabManagerId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<PhysicalExamination>().HasOne(p => p.Appointment).WithMany(p => p.PhysicalExaminations).HasForeignKey(f => f.AppointmentId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<PhysicalExamination>().HasOne(p => p.GlossaryDictionary).WithMany(p => p.PhysicalExaminations).HasForeignKey(f => f.GlossaryDictionaryId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Patient>().HasOne(p => p.Address).WithOne(p => p.Patient).HasForeignKey<Address>(a => a.PatientId);
        builder.Entity<GlossaryDictionary>().HasKey(k => k.Code);
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}
