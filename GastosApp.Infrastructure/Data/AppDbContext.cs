using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GastosApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GastosApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Gasto> Gastos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Gastos)
            .WithOne(g => g.Usuario)
            .HasForeignKey(g => g.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}
