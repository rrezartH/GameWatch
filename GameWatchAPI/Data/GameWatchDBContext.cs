using System;
using System.Collections.Generic;
using GameWatchAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameWatchAPI.Data
{
    public partial class GameWatchDBContext : DbContext
    {
        public GameWatchDBContext()
        {
        }

        public GameWatchDBContext(DbContextOptions<GameWatchDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Biznesi> Biznesi { get; set; } = null!;
        public virtual DbSet<BiznesiKonzola> BiznesiKonzola { get; set; } = null!;
        public virtual DbSet<BizneziKonzolaVideoloja> BizneziKonzolaVideoloja { get; set; } = null!;
        public virtual DbSet<Cmimorja> Cmimorja { get; set; } = null!;
        public virtual DbSet<Fatura> Fatura { get; set; } = null!;
        public virtual DbSet<Konzola> Konzola { get; set; } = null!;
        public virtual DbSet<Lokali> Lokali { get; set; } = null!;
        public virtual DbSet<Stafi> Stafi { get; set; } = null!;
        public virtual DbSet<VideoLoja> VideoLoja { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=GameWatchDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biznesi>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Biznesi__A9D105340FDEAC6D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Emri)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NrTel)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Qyteti)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BiznesiKonzola>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Emri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KonzolaId).HasColumnName("KonzolaID");

                entity.Property(e => e.LokaliId).HasColumnName("LokaliID");

                entity.HasOne(d => d.Konzola)
                    .WithMany(p => p.BiznesiKonzola)
                    .HasForeignKey(d => d.KonzolaId)
                    .HasConstraintName("FK__BiznesiKo__Konzo__300424B4");

                entity.HasOne(d => d.Lokali)
                    .WithMany(p => p.BiznesiKonzola)
                    .HasForeignKey(d => d.LokaliId)
                    .HasConstraintName("FK__BiznesiKo__Lokal__30F848ED");
            });

            modelBuilder.Entity<BizneziKonzolaVideoloja>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.VideoLojaId).HasColumnName("VideoLojaID");

                entity.HasOne(d => d.BiznesiKonzolaNavigation)
                    .WithMany(p => p.BizneziKonzolaVideoloja)
                    .HasForeignKey(d => d.BiznesiKonzola)
                    .HasConstraintName("FK__BizneziKo__Bizne__35BCFE0A");

                entity.HasOne(d => d.VideoLoja)
                    .WithMany(p => p.BizneziKonzolaVideoloja)
                    .HasForeignKey(d => d.VideoLojaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BizneziKo__Video__36B12243");
            });

            modelBuilder.Entity<Cmimorja>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BiznesiId).HasColumnName("BiznesiID");

                entity.Property(e => e.Cmimi).HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.Biznesi)
                    .WithMany(p => p.Cmimorja)
                    .HasForeignKey(d => d.BiznesiId)
                    .HasConstraintName("FK__Cmimorja__Biznes__398D8EEE");
            });

            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CmimiTotal).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.FillimiLojes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LokaliId).HasColumnName("LokaliID");

                entity.Property(e => e.MbarimiLojes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VideoLojaId).HasColumnName("VideoLojaID");

                entity.HasOne(d => d.BiznesiKonzolaNavigation)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.BiznesiKonzola)
                    .HasConstraintName("FK__Fatura__BiznesiK__3C69FB99");

                entity.HasOne(d => d.Lokali)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.LokaliId)
                    .HasConstraintName("FK__Fatura__LokaliID__3E52440B");

                entity.HasOne(d => d.VideoLoja)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.VideoLojaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fatura__VideoLoj__3D5E1FD2");
            });

            modelBuilder.Entity<Konzola>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Modeli)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lokali>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BiznesiId).HasColumnName("BiznesiID");

                entity.Property(e => e.Emri)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NrTel)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Qyteti)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Biznesi)
                    .WithMany(p => p.Lokali)
                    .HasForeignKey(d => d.BiznesiId)
                    .HasConstraintName("FK__Lokali__BiznesiI__276EDEB3");
            });

            modelBuilder.Entity<Stafi>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Stafi__A9D10534885C9DA2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BiznesiId).HasColumnName("BiznesiID");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Emri)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NrTel)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Qyteti)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Biznesi)
                    .WithMany(p => p.Stafi)
                    .HasForeignKey(d => d.BiznesiId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Stafi__BiznesiID__2B3F6F97");
            });

            modelBuilder.Entity<VideoLoja>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Emri)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
