using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class ColegiodbContext : DbContext
{
    public ColegiodbContext()
    {
    }

    public ColegiodbContext(DbContextOptions<ColegiodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencias> Asistencia { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=DESKTOP-82180HC\\SQLEXPRESS;Database=COLEGIODB;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=COLEGIODB;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencias>(entity =>
        {
            entity.HasKey(e => e.ConsecutivoAsistencia).HasName("PK__ASISTENC__E29A3FCB0AE53876");

            entity.ToTable("ASISTENCIA");

            entity.Property(e => e.ConsecutivoAsistencia).HasColumnName("CONSECUTIVO_ASISTENCIA");
            entity.Property(e => e.Asistencia).HasColumnName("ASISTENCIA");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.FkConsecutivoUsuario).HasColumnName("FK_CONSECUTIVO_USUARIO");
            entity.Property(e => e.PorcentajeAsistencia).HasColumnName("PORCENTAJE_ASISTENCIA");

            entity.HasOne(d => d.FkConsecutivoUsuarioNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.FkConsecutivoUsuario)
                .HasConstraintName("FK__ASISTENCI__FK_CO__571DF1D5");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.ConsecutivoClase).HasName("PK__CLASES__1AE4316726933DAC");

            entity.ToTable("CLASES");

            entity.Property(e => e.ConsecutivoClase).HasColumnName("CONSECUTIVO_CLASE");
            entity.Property(e => e.Grado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GRADO");
            entity.Property(e => e.Seccion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("SECCION");
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.ConsecutivoNotas).HasName("PK__NOTAS__EE1103077C984920");

            entity.ToTable("NOTAS");

            entity.Property(e => e.ConsecutivoNotas).HasColumnName("CONSECUTIVO_NOTAS");
            entity.Property(e => e.FkConsecutivoTarea).HasColumnName("FK_CONSECUTIVO_TAREA");
            entity.Property(e => e.FkConsecutivoUsuario).HasColumnName("FK_CONSECUTIVO_USUARIO");

            entity.HasOne(d => d.FkConsecutivoTareaNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.FkConsecutivoTarea)
                .HasConstraintName("FK__NOTAS__FK_CONSEC__5441852A");

            entity.HasOne(d => d.FkConsecutivoUsuarioNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.FkConsecutivoUsuario)
                .HasConstraintName("FK__NOTAS__FK_CONSEC__534D60F1");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.ConsecutivoTarea).HasName("PK__TAREAS__40DD4462B24083BF");

            entity.ToTable("TAREAS");

            entity.Property(e => e.ConsecutivoTarea).HasColumnName("CONSECUTIVO_TAREA");
            entity.Property(e => e.DescripcionTarea)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION_TAREA");
            entity.Property(e => e.NombreTarea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_TAREA");
            entity.Property(e => e.ValorPorcentual).HasColumnName("VALOR_PORCENTUAL");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.ConsecutivoTipoUsuario).HasName("PK__TIPO_USU__7DE0744707D3E418");

            entity.ToTable("TIPO_USUARIO");

            entity.Property(e => e.ConsecutivoTipoUsuario).HasColumnName("CONSECUTIVO_TIPO_USUARIO");
            entity.Property(e => e.TipoUsuario1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TIPO_USUARIO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.ConsecutivoUsuario).HasName("PK__USUARIOS__5E566884A593866E");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.ConsecutivoUsuario).HasColumnName("CONSECUTIVO_USUARIO");
            entity.Property(e => e.FkConsecutivoClase).HasColumnName("FK_CONSECUTIVO_CLASE");
            entity.Property(e => e.FkConsecutivoTipoUsuario).HasColumnName("FK_CONSECUTIVO_TIPO_USUARIO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");

            entity.HasOne(d => d.FkConsecutivoClaseNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkConsecutivoClase)
                .HasConstraintName("FK__USUARIOS__FK_CON__4E88ABD4");

            entity.HasOne(d => d.FkConsecutivoTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkConsecutivoTipoUsuario)
                .HasConstraintName("FK__USUARIOS__FK_CON__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
