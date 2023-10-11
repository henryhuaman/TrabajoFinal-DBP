using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PagPrincipal.Models;

public partial class BdCursos : DbContext
{
    public BdCursos()
    {
    }

    public BdCursos(DbContextOptions<BdCursos> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCurso> TbCursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HENRY ;Initial Catalog=CURSOS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCurso>(entity =>
        {
            entity.HasKey(e => e.CodCur).HasName("PK__TB_CURSO__151E03DE62BA78BD");

            entity.ToTable("TB_CURSOS");

            entity.Property(e => e.CodCur)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CUR");
            entity.Property(e => e.CateCur)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CATE_CUR");
            entity.Property(e => e.NomCur)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_CUR");
            entity.Property(e => e.TamCur)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAM_CUR");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
