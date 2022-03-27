using Clinic.Data;
using Microsoft.EntityFrameworkCore;
using Clinic.Areas.Identity.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Clinic.Areas.Identity;
using Microsoft.AspNetCore.Identity;
using Clinic.Services;

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
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<UserService>();

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

// Comment this line if you want do debug using IIS Express
serviceProvider!.GetService<ApplicationDbContext>()!.Database.Migrate();

// Seed default data
await serviceProvider!.SeedRolesAsync();
var users = await serviceProvider!.SeedUsersAsync();
await serviceProvider!.AssignRoles(users);

app.Run();

