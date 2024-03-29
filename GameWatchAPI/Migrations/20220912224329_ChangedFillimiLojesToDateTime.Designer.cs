﻿// <auto-generated />
using System;
using GameWatchAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameWatchAPI.Migrations
{
    [DbContext(typeof(GameWatchDBContext))]
    [Migration("20220912224329_ChangedFillimiLojesToDateTime")]
    partial class ChangedFillimiLojesToDateTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameWatchAPI.Models.Biznesi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NrTel")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Qyteti")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "UQ__Biznesi__A9D1053477B768F0")
                        .IsUnique();

                    b.ToTable("Biznesi");
                });

            modelBuilder.Entity("GameWatchAPI.Models.BiznesiKonzola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("KonzolaId")
                        .HasColumnType("int")
                        .HasColumnName("KonzolaID");

                    b.Property<int>("LokaliId")
                        .HasColumnType("int")
                        .HasColumnName("LokaliID");

                    b.Property<bool?>("Statusi")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('FALSE')");

                    b.HasKey("Id");

                    b.HasIndex("KonzolaId");

                    b.HasIndex("LokaliId");

                    b.ToTable("BiznesiKonzola");
                });

            modelBuilder.Entity("GameWatchAPI.Models.BizneziKonzolaVideoloja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BiznesiKonzola")
                        .HasColumnType("int");

                    b.Property<int>("VideoLojaId")
                        .HasColumnType("int")
                        .HasColumnName("VideoLojaID");

                    b.HasKey("Id");

                    b.HasIndex("BiznesiKonzola");

                    b.HasIndex("VideoLojaId");

                    b.ToTable("BizneziKonzolaVideoloja");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Cmimorja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BiznesiId")
                        .HasColumnType("int")
                        .HasColumnName("BiznesiID");

                    b.Property<decimal>("Cmimi")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("NrLojtareve")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BiznesiId");

                    b.ToTable("Cmimorja");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Fatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BiznesiKonzola")
                        .HasColumnType("int");

                    b.Property<bool?>("Closed")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('FALSE')");

                    b.Property<decimal?>("CmimiTotal")
                        .HasColumnType("decimal(4,2)");

                    b.Property<DateTime>("FillimiLojes")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<int>("LokaliId")
                        .HasColumnType("int")
                        .HasColumnName("LokaliID");

                    b.Property<string>("MbarimiLojes")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("NrLojtareve")
                        .HasColumnType("int");

                    b.Property<decimal?>("Oret")
                        .HasColumnType("decimal(4,2)");

                    b.Property<int>("VideoLojaId")
                        .HasColumnType("int")
                        .HasColumnName("VideoLojaID");

                    b.HasKey("Id");

                    b.HasIndex("BiznesiKonzola");

                    b.HasIndex("LokaliId");

                    b.HasIndex("VideoLojaId");

                    b.ToTable("Fatura");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Konzola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Modeli")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Konzola");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Lokali", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("BiznesiId")
                        .HasColumnType("int")
                        .HasColumnName("BiznesiID");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NrTel")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Qyteti")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("BiznesiId");

                    b.ToTable("Lokali");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Useri", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("BiznesiId")
                        .HasColumnType("int")
                        .HasColumnName("BiznesiID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LokaliId")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Qyteti")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("UserId")
                        .HasName("PK__Useri__1788CC4C1D6A05C2");

                    b.HasIndex("BiznesiId");

                    b.HasIndex("LokaliId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("GameWatchAPI.Models.VideoLoja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("VideoLoja");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GameWatchAPI.Models.BiznesiKonzola", b =>
                {
                    b.HasOne("GameWatchAPI.Models.Konzola", "Konzola")
                        .WithMany("BiznesiKonzola")
                        .HasForeignKey("KonzolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__BiznesiKo__Konzo__48CFD27E");

                    b.HasOne("GameWatchAPI.Models.Lokali", "Lokali")
                        .WithMany("BiznesiKonzola")
                        .HasForeignKey("LokaliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__BiznesiKo__Lokal__49C3F6B7");

                    b.Navigation("Konzola");

                    b.Navigation("Lokali");
                });

            modelBuilder.Entity("GameWatchAPI.Models.BizneziKonzolaVideoloja", b =>
                {
                    b.HasOne("GameWatchAPI.Models.BiznesiKonzola", "BiznesiKonzolaNavigation")
                        .WithMany("BizneziKonzolaVideoloja")
                        .HasForeignKey("BiznesiKonzola")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__BizneziKo__Bizne__4E88ABD4");

                    b.HasOne("GameWatchAPI.Models.VideoLoja", "VideoLoja")
                        .WithMany("BizneziKonzolaVideoloja")
                        .HasForeignKey("VideoLojaId")
                        .IsRequired()
                        .HasConstraintName("FK__BizneziKo__Video__4F7CD00D");

                    b.Navigation("BiznesiKonzolaNavigation");

                    b.Navigation("VideoLoja");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Cmimorja", b =>
                {
                    b.HasOne("GameWatchAPI.Models.Biznesi", "Biznesi")
                        .WithMany("Cmimorja")
                        .HasForeignKey("BiznesiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Cmimorja__Biznes__52593CB8");

                    b.Navigation("Biznesi");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Fatura", b =>
                {
                    b.HasOne("GameWatchAPI.Models.BiznesiKonzola", "BiznesiKonzolaNavigation")
                        .WithMany("Fatura")
                        .HasForeignKey("BiznesiKonzola")
                        .HasConstraintName("FK__Fatura__BiznesiK__5535A963");

                    b.HasOne("GameWatchAPI.Models.Lokali", "Lokali")
                        .WithMany("Fatura")
                        .HasForeignKey("LokaliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Fatura__LokaliID__571DF1D5");

                    b.HasOne("GameWatchAPI.Models.VideoLoja", "VideoLoja")
                        .WithMany("Fatura")
                        .HasForeignKey("VideoLojaId")
                        .IsRequired()
                        .HasConstraintName("FK__Fatura__VideoLoj__5629CD9C");

                    b.Navigation("BiznesiKonzolaNavigation");

                    b.Navigation("Lokali");

                    b.Navigation("VideoLoja");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Lokali", b =>
                {
                    b.HasOne("GameWatchAPI.Models.Biznesi", "Biznesi")
                        .WithMany("Lokali")
                        .HasForeignKey("BiznesiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Lokali__BiznesiI__398D8EEE");

                    b.Navigation("Biznesi");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Useri", b =>
                {
                    b.HasOne("GameWatchAPI.Models.Biznesi", "Biznesi")
                        .WithMany("Useri")
                        .HasForeignKey("BiznesiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Useri__BiznesiID__440B1D61");

                    b.HasOne("GameWatchAPI.Models.Lokali", "Lokali")
                        .WithMany("Useri")
                        .HasForeignKey("LokaliId")
                        .HasConstraintName("FK__AspNetUse__Lokal__3A4CA8FD");

                    b.Navigation("Biznesi");

                    b.Navigation("Lokali");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("GameWatchAPI.Models.Useri", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("GameWatchAPI.Models.Useri", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameWatchAPI.Models.Useri", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("GameWatchAPI.Models.Useri", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameWatchAPI.Models.Biznesi", b =>
                {
                    b.Navigation("Cmimorja");

                    b.Navigation("Lokali");

                    b.Navigation("Useri");
                });

            modelBuilder.Entity("GameWatchAPI.Models.BiznesiKonzola", b =>
                {
                    b.Navigation("BizneziKonzolaVideoloja");

                    b.Navigation("Fatura");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Konzola", b =>
                {
                    b.Navigation("BiznesiKonzola");
                });

            modelBuilder.Entity("GameWatchAPI.Models.Lokali", b =>
                {
                    b.Navigation("BiznesiKonzola");

                    b.Navigation("Fatura");

                    b.Navigation("Useri");
                });

            modelBuilder.Entity("GameWatchAPI.Models.VideoLoja", b =>
                {
                    b.Navigation("BizneziKonzolaVideoloja");

                    b.Navigation("Fatura");
                });
#pragma warning restore 612, 618
        }
    }
}
