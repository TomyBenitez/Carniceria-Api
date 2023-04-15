using System;
using System.Collections.Generic;
using Carniceria_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Carniceria_Api.Data;

public partial class SmartsofTomasbenitezContext : DbContext
{
    public SmartsofTomasbenitezContext()
    {
    }

    public SmartsofTomasbenitezContext(DbContextOptions<SmartsofTomasbenitezContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cobrador> Cobradors { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
           // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseMySql("server=184.175.77.148;database=smartsof_tomasbenitez;uid=smartsof_tomasbenitez;password=tomasbenitez", ServerVersion.Parse("10.3.38-mariadb"));
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApellidoNombre).HasColumnName("Apellido_Nombre");
        });

        modelBuilder.Entity<Cobrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Cobrador");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApellidoNombre).HasColumnName("Apellido_Nombre");
            entity.Property(e => e.TipoUsuario).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Producto");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Monto).HasPrecision(12, 2);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ClienteId, "IX_Ventas_ClienteId");

            entity.HasIndex(e => e.CobradorId, "IX_Ventas_CobradorId");

            entity.HasIndex(e => e.ProductosId, "IX_Ventas_ProductosId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClienteId).HasColumnType("int(11)");
            entity.Property(e => e.CobradorId).HasColumnType("int(11)");
            entity.Property(e => e.Fecha).HasMaxLength(6);
            entity.Property(e => e.ProductosId).HasColumnType("int(11)");

            //entity.HasOne(d => d.ClienteId).WithMany(p => p.Ventas).HasForeignKey(d => d.ClienteId);

            //entity.HasOne(d => d.CobradorId).WithMany(p => p.Ventas).HasForeignKey(d => d.CobradorId);

            //entity.HasOne(d => d.ClienteId).WithMany(p => p.Ventas).HasForeignKey(d => d.ProductosId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
