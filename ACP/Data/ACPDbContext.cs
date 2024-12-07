using ACP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ACP.Data;

public class ACPDbContext : IdentityDbContext<ApplicationUser>
{

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Color> Colores { get; set; }
    public DbSet<Fabricante> Fabricantes { get; set; }
    public DbSet<Referencia> Referencias { get; set; }

    public ACPDbContext(DbContextOptions<ACPDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        var toyotaId = Guid.NewGuid(); 
        var fordId = Guid.NewGuid();
        var chevroletId = Guid.NewGuid();

        builder.Entity<Fabricante>().HasData(
            new Fabricante { Id = toyotaId, Nombre = "Toyota" }, 
            new Fabricante { Id = fordId, Nombre = "Ford" }, 
            new Fabricante { Id = chevroletId, Nombre = "Chevrolet" }
            );

        builder.Entity<Color>().HasData(
            new Color { Id = Guid.NewGuid(), Nombre = "Rojo" },
            new Color { Id = Guid.NewGuid(), Nombre = "Azul" },
            new Color { Id = Guid.NewGuid(), Nombre = "Negro" }
            );

        builder.Entity<Vehiculo>()
            .HasOne(v => v.Referencia)
            .WithMany(r => r.Vehiculos)
            .HasForeignKey(v => v.ReferenciaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Referencia>().HasData(
            new Referencia { 
                Id = Guid.NewGuid(), 
                Nombre = "Corolla", 
                FabricanteId = toyotaId }, 
            new Referencia { 
                Id = Guid.NewGuid(), 
                Nombre = "Camry", 
                FabricanteId = toyotaId
            }, 
            new Referencia { 
                Id = Guid.NewGuid(), 
                Nombre = "F-150", 
                FabricanteId = fordId
            }, 
            new Referencia { 
                Id = Guid.NewGuid(), 
                Nombre = "Mustang", 
                FabricanteId = fordId
            }, 
            new Referencia { 
                Id = Guid.NewGuid(), 
                Nombre = "Captiva", 
                FabricanteId = chevroletId
            }, 
            new Referencia { 
                Id = Guid.NewGuid(), 
                Nombre = "Onix", 
                FabricanteId = chevroletId
            }
            );
    }
}
