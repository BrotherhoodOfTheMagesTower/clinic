using Clinic.Areas.Identity;
using Clinic.Areas.Identity.Data;
using Clinic.Data;
using Clinic.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Blazored.Toast;
using Clinic.Data.Seeders;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
     options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
//Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RegistrarService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<LabManagerService>();
builder.Services.AddScoped<LabTechnicianService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<LaboratoryExaminationService>();
builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var serviceProvider = app.Services?.GetService<IServiceScopeFactory>()?.CreateScope().ServiceProvider;
serviceProvider!.GetService<ApplicationDbContext>()!.Database.Migrate();

// Provides an administrator account and a default Glossary with 6 predefined Examinations
await serviceProvider!.SeedRequiredData();

// Seed default users with roles - 3 Doctors, 1 Registrar, 2 Lab Technicians, 2 Lab Managers
var users = serviceProvider!.SeedUsers();
await serviceProvider!.AssignRoles(users);

//Seed other default entities - 3 Patients, 2 Addresses, 4 Appointments, 4 Examinations
await serviceProvider!.SeedDefaultEntities();

app.Run();

