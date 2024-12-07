using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ACP.Data;
using ACP.Models;
using ACP.Repositories.Interfaces;
using ACP.Repositories.Implementations;
using ACP.Services.Interfaces;
using ACP.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ACPDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ACPDbContextConnection' not found.");

// DbContext
builder.Services.AddDbContext<ACPDbContext>(options => options.UseSqlServer(connectionString));

// Repositorios
builder.Services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFabricanteRepository, FabricanteRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IReferenciaRepository, ReferenciaRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();

// Servicios
builder.Services.AddScoped<IServicioVehiculo, ServicioVehiculo>();
builder.Services.AddScoped<IServicioCliente, ServicioCliente>();
builder.Services.AddScoped<IServicioFabricante, ServicioFabricante>();
builder.Services.AddScoped<IServicioColor, ServicioColor>();
builder.Services.AddScoped<IServicioReferencia, ServicioReferencia>();

// Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ACPDbContext>();

// Vistas razor para identity
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    await CreateRolesAndUsers(roleManager, userManager);
}

app.Run();

async Task CreateRolesAndUsers(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
{
    var roles = new[] { "Administrador", "Operario" };

    IdentityResult roleResult;

    foreach (var roleName in roles)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist) roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
    }

    var user = await userManager.FindByEmailAsync(builder.Configuration["AdminUser:Email"]!);

    if (user == null)
    {
        var newUser = new ApplicationUser
        {
            UserName = builder.Configuration["AdminUser:Email"],
            Email = builder.Configuration["AdminUser:Email"],
            FirstName = builder.Configuration["AdminUser:FirstName"]!,
            LastName = builder.Configuration["AdminUser:LastName"]!,
            PhoneNumber = builder.Configuration["AdminUser:PhoneNumber"]
        };
        var createUser = await userManager
            .CreateAsync(newUser, builder.Configuration["AdminUser:Password"]!);

        if (createUser.Succeeded) await userManager.AddToRoleAsync(newUser, "Administrador");
    }
}