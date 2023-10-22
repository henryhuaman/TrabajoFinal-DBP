using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PagPrincipal.Models;

public partial class BdWeb : DbContext
{
    public BdWeb()
    {
    }

    public BdWeb(DbContextOptions<BdWeb> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbCurso> TbCursos { get; set; }

    public virtual DbSet<TbProfesore> TbProfesores { get; set; }

    public virtual DbSet<TbVentum> TbVenta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HENRY;Initial Catalog=WEB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.CodCli).HasName("PK__TB_CLIEN__050CCFE5D545ACC9");

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.CodCli)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Cli");
            entity.Property(e => e.ContraCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contra_Cli");
            entity.Property(e => e.CorCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cor_Cli");
            entity.Property(e => e.DniCli)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Dni_Cli");
            entity.Property(e => e.NomCli)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Nom_Cli");
            entity.Property(e => e.TlfCli)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Tlf_Cli");
        });

        modelBuilder.Entity<TbCurso>(entity =>
        {
            entity.HasKey(e => e.CodCur).HasName("PK__TB_CURSO__050C04CBAC84CAD1");

            entity.ToTable("TB_CURSOS");

            entity.Property(e => e.CodCur)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Cur");
            entity.Property(e => e.CateCur)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cate_Cur");
            entity.Property(e => e.CodPro)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Pro");
            entity.Property(e => e.DesCur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Des_Cur");
            entity.Property(e => e.NomCur)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Nom_Cur");
            entity.Property(e => e.PreCur)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Pre_Cur");

            entity.HasOne(d => d.CodProNavigation).WithMany(p => p.TbCursos)
                .HasForeignKey(d => d.CodPro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_CURSOS__Cod_P__4316F928");
        });

        modelBuilder.Entity<TbProfesore>(entity =>
        {
            entity.HasKey(e => e.CodPro).HasName("PK__TB_PROFE__02A11BC55923B7F8");

            entity.ToTable("TB_PROFESORES");

            entity.Property(e => e.CodPro)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Pro");
            entity.Property(e => e.ContraPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contra_Pro");
            entity.Property(e => e.CorPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cor_Pro");
            entity.Property(e => e.DesPro)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Des_Pro");
            entity.Property(e => e.DniPro)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Dni_Pro");
            entity.Property(e => e.NomPro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Nom_Pro");
            entity.Property(e => e.TlfPro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Tlf_Pro");
        });

        modelBuilder.Entity<TbVentum>(entity =>
        {
            entity.HasKey(e => e.CodCompra).HasName("PK__TB_Venta__D178AF590AA86DAA");

            entity.ToTable("TB_Venta");

            entity.Property(e => e.CodCompra).HasColumnName("Cod_compra");
            entity.Property(e => e.CodCli)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Cli");
            entity.Property(e => e.CodCur)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Cur");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("date")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.CodCliNavigation).WithMany(p => p.TbVenta)
                .HasForeignKey(d => d.CodCli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_Venta__Cod_Cl__46E78A0C");

            entity.HasOne(d => d.CodCurNavigation).WithMany(p => p.TbVenta)
                .HasForeignKey(d => d.CodCur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_Venta__Cod_Cu__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
