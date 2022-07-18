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
        public virtual DbSet<Cmimorja> Cmimorja { get; set; } = null!;
        public virtual DbSet<Fatura> Fatura { get; set; } = null!;
        public virtual DbSet<Lokali> Lokali { get; set; } = null!;
        public virtual DbSet<PlayStation> PlayStation { get; set; } = null!;
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
                entity.HasIndex(e => e.Email, "UQ__Biznesi__A9D10534B9E25BA9")
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

            modelBuilder.Entity<Cmimorja>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BiznesiId).HasColumnName("BiznesiID");

                entity.Property(e => e.Cmimi).HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.Biznesi)
                    .WithMany(p => p.Cmimorja)
                    .HasForeignKey(d => d.BiznesiId)
                    .HasConstraintName("FK__Cmimorja__Biznes__45F365D3");
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

                entity.Property(e => e.PlayStationId).HasColumnName("PlayStationID");

                entity.Property(e => e.VideoLojaId).HasColumnName("VideoLojaID");

                entity.HasOne(d => d.Lokali)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.LokaliId)
                    .HasConstraintName("FK__Fatura__LokaliID__4AB81AF0");

                entity.HasOne(d => d.PlayStation)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.PlayStationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fatura__PlayStat__48CFD27E");

                entity.HasOne(d => d.VideoLoja)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.VideoLojaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fatura__VideoLoj__49C3F6B7");
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

            modelBuilder.Entity<PlayStation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LokaliId).HasColumnName("LokaliID");

                entity.Property(e => e.Modeli)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lokali)
                    .WithMany(p => p.PlayStation)
                    .HasForeignKey(d => d.LokaliId)
                    .HasConstraintName("FK__PlayStati__Lokal__403A8C7D");
            });

            modelBuilder.Entity<Stafi>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Stafi__A9D105346CD25303")
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
                    .HasConstraintName("FK__Stafi__BiznesiID__3D5E1FD2");
            });

            modelBuilder.Entity<VideoLoja>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Emri)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PlayStationId).HasColumnName("PlayStationID");

                entity.HasOne(d => d.PlayStation)
                    .WithMany(p => p.VideoLoja)
                    .HasForeignKey(d => d.PlayStationId)
                    .HasConstraintName("FK__VideoLoja__PlayS__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
