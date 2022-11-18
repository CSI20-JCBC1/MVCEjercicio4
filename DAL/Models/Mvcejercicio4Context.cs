using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class Mvcejercicio4Context : DbContext
{
    public Mvcejercicio4Context()
    {
    }

    public Mvcejercicio4Context(DbContextOptions<Mvcejercicio4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=MVCEjercicio4;User Id=postgres;Password=Juancarbc2001");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Areas_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area1)
                .HasColumnType("character varying")
                .HasColumnName("Area");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Empleados_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.Nombre).HasColumnType("character varying");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("areaFK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
