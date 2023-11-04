    using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeCourse.Models;

public partial class BDWeb : DbContext
{
    public BDWeb()
    {
    }

    public BDWeb(DbContextOptions<BDWeb> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Inscripcion> Inscripcions { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HENRY;Initial Catalog=mydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Administ__3214EC27B74144A6");

            entity.ToTable("Administrador");

            entity.HasIndex(e => e.Id, "UC_Administrador_ID").IsUnique();

            entity.HasIndex(e => e.Correo, "UC_Administrador_correo").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("correo");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curso__3214EC2769E2891A");

            entity.ToTable("Curso");

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ProfesorId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("Profesor_ID");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.ProfesorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Curso_Profesor");
        });

        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inscripc__3214EC2706429BF4");

            entity.ToTable("Inscripcion");

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.CursoId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("curso_ID");
            entity.Property(e => e.InsFecha)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("insFecha");
            entity.Property(e => e.UsuarioId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("usuario_ID");

            entity.HasOne(d => d.Curso).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscripcion_Curso");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscripcion_Usuario");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3214EC27502E6268");

            entity.ToTable("Profesor");

            entity.HasIndex(e => e.Id, "UC_Profesor_ID").IsUnique();

            entity.HasIndex(e => e.Correo, "UC_Profesor_correo").IsUnique();

            entity.HasIndex(e => e.Dni, "UC_Profesor_dni").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC2730BFCFA0");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Id, "UC_Usuario_ID").IsUnique();

            entity.HasIndex(e => e.Correo, "UC_Usuario_correo").IsUnique();

            entity.HasIndex(e => e.Dni, "UC_Usuario_dni").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
