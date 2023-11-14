using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeCourse.Models;

public partial class BdWeb : DbContext
{
    public BdWeb()
    {
    }

    public BdWeb(DbContextOptions<BdWeb> options)
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
        => optionsBuilder.UseSqlServer("Data Source=SQL8006.site4now.net;Initial Catalog=db_aa1076_dbpdb;User Id=db_aa1076_dbpdb_admin;Password=12345hola");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Administ__3214EC2724419A61");

            entity.ToTable("Administrador");

            entity.HasIndex(e => e.Id, "ID_UNIQUE_ADMINISTRADOR").IsUnique();

            entity.HasIndex(e => e.Correo, "correo_UNIQUE_ADMINISTRADOR").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .HasColumnName("ID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(45)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .HasColumnName("correo");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curso__3214EC278A71963D");

            entity.ToTable("Curso");

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .HasColumnName("ID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(45)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.ProfesorId)
                .HasMaxLength(45)
                .HasColumnName("Profesor_ID");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.ProfesorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Curso_Profesor");
        });

        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Inscripcion");

            entity.Property(e => e.CodOpe)
                .HasMaxLength(45)
                .HasColumnName("codOpe");
            entity.Property(e => e.CursoId)
                .HasMaxLength(45)
                .HasColumnName("curso_ID");
            entity.Property(e => e.InsFecha)
                .HasMaxLength(45)
                .HasColumnName("insFecha");
            entity.Property(e => e.UsuarioId)
                .HasMaxLength(45)
                .HasColumnName("usuario_ID");

            entity.HasOne(d => d.Curso).WithMany()
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuario_has_Curso_Curso1");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuario_has_Curso_Usuario1");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3214EC2762A8F808");

            entity.ToTable("Profesor");

            entity.HasIndex(e => e.Id, "ID_UNIQUE_PROFESOR").IsUnique();

            entity.HasIndex(e => e.Correo, "correo_UNIQUE_PROFESOR").IsUnique();

            entity.HasIndex(e => e.Dni, "dni_UNIQUE_PROFESOR").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .HasColumnName("ID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(45)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .HasColumnName("correo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Dni)
                .HasMaxLength(45)
                .HasColumnName("dni");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC273851B94F");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Id, "ID_UNIQUE_USUARIO").IsUnique();

            entity.HasIndex(e => e.Correo, "correo_UNIQUE_USUARIO").IsUnique();

            entity.HasIndex(e => e.Dni, "dni_UNIQUE_USUARIO").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .HasColumnName("ID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(45)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(45)
                .HasColumnName("dni");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
