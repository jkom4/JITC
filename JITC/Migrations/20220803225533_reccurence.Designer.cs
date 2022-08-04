﻿// <auto-generated />
using System;
using JITC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JITC.Migrations
{
    [DbContext(typeof(JITCDbContext))]
    [Migration("20220803225533_reccurence")]
    partial class reccurence
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JITC.Models.Aeroport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Aeroport");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Latitude = 50.63583079,
                            Longitude = 5.4393315759999998,
                            Nom = "Liège"
                        },
                        new
                        {
                            Id = 2,
                            Latitude = 50.900829729999998,
                            Longitude = 4.4839980639999997,
                            Nom = "Bruxelles"
                        },
                        new
                        {
                            Id = 3,
                            Latitude = 51.193165894000003,
                            Longitude = 2.8581632340000001,
                            Nom = "Oostende"
                        },
                        new
                        {
                            Id = 4,
                            Latitude = 50.455998176000001,
                            Longitude = 4.4516648600000002,
                            Nom = "Charleroi"
                        });
                });

            modelBuilder.Entity("JITC.Models.Appareil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacite_Cab")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Moteur")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Statut")
                        .HasColumnType("bit");

                    b.Property<float>("Vitesse")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Appareil");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacite_Cab = 5,
                            Description = "",
                            Moteur = "Deux turbines du modèle de Rolls Royce 250-C20F",
                            Nom = "Eurocopter AS 355 F1/F2 Ecureuil III",
                            Statut = false,
                            Vitesse = 220f
                        },
                        new
                        {
                            Id = 2,
                            Capacite_Cab = 4,
                            Description = "",
                            Moteur = "Une turbine du type Rolls Royce 250-C20B",
                            Nom = "Bell 206 JetRanger",
                            Statut = false,
                            Vitesse = 190f
                        },
                        new
                        {
                            Id = 3,
                            Capacite_Cab = 3,
                            Description = "",
                            Moteur = "Un piston du type Lycoming modèle IO-540",
                            Nom = "Robinson R44 Raven II",
                            Statut = false,
                            Vitesse = 190f
                        });
                });

            modelBuilder.Entity("JITC.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            Birthdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "3f37a638-1b0d-4a98-b688-d4f5de598536",
                            Email = "M.Ney@jitc.com",
                            EmailConfirmed = false,
                            Firstname = "Mo",
                            LockoutEnabled = false,
                            Name = "Ney",
                            NormalizedEmail = "M.NEY@JITC.COM",
                            NormalizedUserName = "MONEY",
                            PasswordHash = "AQAAAAEAACcQAAAAENpeVlkiZF4fSmAwPlaD38KXZTEyMxhU7bM/JzOx/mw/e5xmPJfnMQaOKNmmi88tNg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fb6c759e-9af0-4287-8ba9-6d9992fab183",
                            TwoFactorEnabled = false,
                            UserName = "MoNey"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            Birthdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "5b8d54f4-cc1a-47f9-bdde-5a5fef10b081",
                            Email = "D.Balav@jitc.com",
                            EmailConfirmed = false,
                            Firstname = "Daniele",
                            LockoutEnabled = false,
                            Name = "Balav",
                            NormalizedEmail = "D.BALAV@JITC.COM",
                            NormalizedUserName = "DANIELEBALAV",
                            PasswordHash = "AQAAAAEAACcQAAAAEMi4KC7/DZMwP5PRzVU781EJQ1a/jq6HadO5Zt2RX6f8jNP4gm2Ekc8BDcLPXTp+lQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "69a967cc-3185-40c0-8cc0-393e0250d3a4",
                            TwoFactorEnabled = false,
                            UserName = "DanieleBalav"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            Birthdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "372ce3e6-e02c-483f-bebd-b40924440087",
                            Email = "T.Sabine@jitc.com",
                            EmailConfirmed = false,
                            Firstname = "Thierry",
                            LockoutEnabled = false,
                            Name = "Sabine",
                            NormalizedEmail = "T.SABINE@JITC.COM",
                            NormalizedUserName = "THIERRYSABINE",
                            PasswordHash = "AQAAAAEAACcQAAAAEDzMkJ7wgCiAZGvrWf253Yrp0GbVUWS4iup5IM93aBYy0wQcPZq/qhx2CPEGq4vA6Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0d274564-2677-42dd-b15f-720c24546ab0",
                            TwoFactorEnabled = false,
                            UserName = "ThierrySabine"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            Birthdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "f1996ce2-ed89-4ec8-9578-d13620263b79",
                            Email = "E.Coptere@jitc.com",
                            EmailConfirmed = false,
                            Firstname = "Eli",
                            LockoutEnabled = false,
                            Name = "Copetre",
                            NormalizedEmail = "E.COPTERE@JITC.COM",
                            NormalizedUserName = "ELICOPTERE",
                            PasswordHash = "AQAAAAEAACcQAAAAEJd4nlSx8aWZ0r3gBNa0CT1WwEnw65Id6OQKsg9fg3tvE42KUDJ7xP7tLt8JeV0K7w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "28e6d842-de39-45ce-821e-1bfaa206d25d",
                            TwoFactorEnabled = false,
                            UserName = "EliCoptere"
                        });
                });

            modelBuilder.Entity("JITC.Models.ModifVol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("VolModifs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ModifVol");
                });

            modelBuilder.Entity("JITC.Models.Reservation", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("place")
                        .HasColumnType("int");

                    b.Property<int?>("volId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("volId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("JITC.Models.Vol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AeroportArriveId")
                        .HasColumnType("int");

                    b.Property<int?>("AeroportDepartId")
                        .HasColumnType("int");

                    b.Property<int>("AppareilId")
                        .HasColumnType("int");

                    b.Property<double?>("Distance")
                        .HasColumnType("float");

                    b.Property<DateTime>("HeureArrivePrevue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HeureArriveReelle")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HeureDepartPrevue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HeureDepartReelle")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifVolId")
                        .HasColumnType("int");

                    b.Property<int>("NombrePlace")
                        .HasColumnType("int");

                    b.Property<string>("PiloteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Raison")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Retard")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AeroportArriveId");

                    b.HasIndex("AeroportDepartId");

                    b.HasIndex("AppareilId");

                    b.HasIndex("ModifVolId");

                    b.HasIndex("PiloteId");

                    b.ToTable("Vol");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "ecbfb05a-22d1-4205-952b-6d72245e4366",
                            Name = "Responsable",
                            NormalizedName = "RESPONSABLE"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "8dab1a28-2f72-4121-b7d3-cff6226aae76",
                            Name = "Pilote",
                            NormalizedName = "PILOTE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "3",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "4",
                            RoleId = "2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JITC.Models.Reservation", b =>
                {
                    b.HasOne("JITC.Models.ApplicationUser", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId");

                    b.HasOne("JITC.Models.Vol", "vol")
                        .WithMany("Reservations")
                        .HasForeignKey("volId");

                    b.Navigation("User");

                    b.Navigation("vol");
                });

            modelBuilder.Entity("JITC.Models.Vol", b =>
                {
                    b.HasOne("JITC.Models.Aeroport", "AeroportArrive")
                        .WithMany()
                        .HasForeignKey("AeroportArriveId");

                    b.HasOne("JITC.Models.Aeroport", "AeroportDepart")
                        .WithMany()
                        .HasForeignKey("AeroportDepartId");

                    b.HasOne("JITC.Models.Appareil", "Appareil")
                        .WithMany("Vols")
                        .HasForeignKey("AppareilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JITC.Models.ModifVol", "ModifVol")
                        .WithMany("Vols")
                        .HasForeignKey("ModifVolId");

                    b.HasOne("JITC.Models.ApplicationUser", "Pilote")
                        .WithMany("Vols")
                        .HasForeignKey("PiloteId");

                    b.Navigation("AeroportArrive");

                    b.Navigation("AeroportDepart");

                    b.Navigation("Appareil");

                    b.Navigation("ModifVol");

                    b.Navigation("Pilote");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JITC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JITC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JITC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JITC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JITC.Models.Appareil", b =>
                {
                    b.Navigation("Vols");
                });

            modelBuilder.Entity("JITC.Models.ApplicationUser", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Vols");
                });

            modelBuilder.Entity("JITC.Models.ModifVol", b =>
                {
                    b.Navigation("Vols");
                });

            modelBuilder.Entity("JITC.Models.Vol", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
