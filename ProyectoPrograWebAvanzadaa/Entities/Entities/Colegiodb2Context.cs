using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class Colegiodb2Context : DbContext
{
    public Colegiodb2Context()
    {
    }

    public Colegiodb2Context(DbContextOptions<Colegiodb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencia { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Nota> Nota { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> AspNetUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//    => optionsBuilder.UseSqlServer("Server=DESKTOP-82180HC\\SQLEXPRESS;Database=COLEGIODB2;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PK__ASISTENC__3956DEE62D43207A");

            entity.ToTable("ASISTENCIA");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__ASISTENCI__IdUsu__412EB0B6");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.IdClase).HasName("PK__CLASE__003FCC6F71555151");

            entity.ToTable("CLASE");

            entity.Property(e => e.Grado)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Seccion)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.IdNota).HasName("PK__NOTA__4B2ACFF2DE7E1382");

            entity.ToTable("NOTA");

            entity.Property(e => e.NotaTarea)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTareaNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdTarea)
                .HasConstraintName("FK__NOTA__IdTarea__4316F928");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__NOTA__IdUsuario__4222D4EF");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__TAREA__EADE90981007FDDF");

            entity.ToTable("TAREA");

            entity.Property(e => e.DescripcionTarea)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NombreTarea)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USUARIO__5B65BF9704C5191E");

            entity.ToTable("AspNetUsers");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()"); // Para SQL Server

            entity.HasOne(d => d.IdClaseNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdClase)
                .HasConstraintName("FK__USUARIO__IdClase__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
