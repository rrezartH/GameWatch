using System;
using System.Collections.Generic;
using GameWatchAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameWatchAPI.Data
{
    public partial class GameWatchDBContext : IdentityDbContext<Useri, IdentityRole<int>, int>
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
        public virtual DbSet<UserRole> UserRole { get; set; } = null!;
        public virtual DbSet<Useri> Useri { get; set; } = null!;
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Biznesi>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Biznesi__A9D1053477B768F0")
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

                entity.Property(e => e.Statusi)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");

                entity.HasOne(d => d.Konzola)
                    .WithMany(p => p.BiznesiKonzola)
                    .HasForeignKey(d => d.KonzolaId)
                    .HasConstraintName("FK__BiznesiKo__Konzo__48CFD27E");

                entity.HasOne(d => d.Lokali)
                    .WithMany(p => p.BiznesiKonzola)
                    .HasForeignKey(d => d.LokaliId)
                    .HasConstraintName("FK__BiznesiKo__Lokal__49C3F6B7");
            });

            modelBuilder.Entity<BizneziKonzolaVideoloja>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.VideoLojaId).HasColumnName("VideoLojaID");

                entity.HasOne(d => d.BiznesiKonzolaNavigation)
                    .WithMany(p => p.BizneziKonzolaVideoloja)
                    .HasForeignKey(d => d.BiznesiKonzola)
                    .HasConstraintName("FK__BizneziKo__Bizne__4E88ABD4");

                entity.HasOne(d => d.VideoLoja)
                    .WithMany(p => p.BizneziKonzolaVideoloja)
                    .HasForeignKey(d => d.VideoLojaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BizneziKo__Video__4F7CD00D");
            });

            modelBuilder.Entity<Cmimorja>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BiznesiId).HasColumnName("BiznesiID");

                entity.Property(e => e.Cmimi).HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.Biznesi)
                    .WithMany(p => p.Cmimorja)
                    .HasForeignKey(d => d.BiznesiId)
                    .HasConstraintName("FK__Cmimorja__Biznes__52593CB8");
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

                entity.Property(e => e.Oret).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.VideoLojaId).HasColumnName("VideoLojaID");

                entity.HasOne(d => d.BiznesiKonzolaNavigation)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.BiznesiKonzola)
                    .HasConstraintName("FK__Fatura__BiznesiK__5535A963");

                entity.HasOne(d => d.Lokali)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.LokaliId)
                    .HasConstraintName("FK__Fatura__LokaliID__571DF1D5");

                entity.HasOne(d => d.VideoLoja)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.VideoLojaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fatura__VideoLoj__5629CD9C");
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
                    .HasConstraintName("FK__Lokali__BiznesiI__398D8EEE");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleName)
                    .HasName("PK__UserRole__8A2B61618B3A56F9");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Useri>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Useri__1788CC4C1D6A05C2");

                entity.Property(e => e.BiznesiId).HasColumnName("BiznesiID");

                entity.Property(e => e.Emri)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LokaliId).HasColumnName("LokaliID");

                entity.Property(e => e.Qyteti)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Biznesi)
                    .WithMany(p => p.Useri)
                    .HasForeignKey(d => d.BiznesiId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Useri__BiznesiID__440B1D61");

                entity.HasOne(d => d.Lokali)
                    .WithMany(p => p.Useri)
                    .HasForeignKey(d => d.LokaliId)
                    .HasConstraintName("FK__Useri__LokaliID__4316F928");

                entity.HasOne(d => d.RoleNameNavigation)
                    .WithMany(p => p.Useri)
                    .HasForeignKey(d => d.RoleName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Useri__RoleName__4222D4EF");
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
