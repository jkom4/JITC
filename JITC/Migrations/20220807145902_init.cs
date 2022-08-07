using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeroport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appareil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Capacite_Cab = table.Column<int>(type: "int", nullable: false),
                    Vitesse = table.Column<float>(type: "real", nullable: false),
                    Moteur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appareil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModifVol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolModifs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifVol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AeroportDepartId = table.Column<int>(type: "int", nullable: true),
                    AeroportArriveId = table.Column<int>(type: "int", nullable: true),
                    NombrePlace = table.Column<int>(type: "int", nullable: false),
                    HeureDepartPrevue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureArrivePrevue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureDepartReelle = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeureArriveReelle = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PiloteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Distance = table.Column<double>(type: "float", nullable: true),
                    AppareilId = table.Column<int>(type: "int", nullable: false),
                    Recurrence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Retard = table.Column<bool>(type: "bit", nullable: false),
                    Raison = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifVolId = table.Column<int>(type: "int", nullable: true),
                    ModifDate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vol_Aeroport_AeroportArriveId",
                        column: x => x.AeroportArriveId,
                        principalTable: "Aeroport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vol_Aeroport_AeroportDepartId",
                        column: x => x.AeroportDepartId,
                        principalTable: "Aeroport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vol_Appareil_AppareilId",
                        column: x => x.AppareilId,
                        principalTable: "Appareil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vol_AspNetUsers_PiloteId",
                        column: x => x.PiloteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vol_ModifVol_ModifVolId",
                        column: x => x.ModifVolId,
                        principalTable: "ModifVol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    volId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    place = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_Vol_volId",
                        column: x => x.volId,
                        principalTable: "Vol",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Aeroport",
                columns: new[] { "Id", "Latitude", "Longitude", "Nom" },
                values: new object[,]
                {
                    { 1, 50.63583079, 5.4393315759999998, "Liège" },
                    { 2, 50.900829729999998, 4.4839980639999997, "Bruxelles" },
                    { 3, 51.193165894000003, 2.8581632340000001, "Oostende" },
                    { 4, 50.455998176000001, 4.4516648600000002, "Charleroi" }
                });

            migrationBuilder.InsertData(
                table: "Appareil",
                columns: new[] { "Id", "Capacite_Cab", "Description", "Moteur", "Nom", "Statut", "Vitesse" },
                values: new object[,]
                {
                    { 1, 5, "", "Deux turbines du modèle de Rolls Royce 250-C20F", "Eurocopter AS 355 F1/F2 Ecureuil III", false, 220f },
                    { 2, 4, "", "Une turbine du type Rolls Royce 250-C20B", "Bell 206 JetRanger", false, 190f },
                    { 3, 3, "", "Un piston du type Lycoming modèle IO-540", "Robinson R44 Raven II", false, 190f }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "ec0598de-8669-42dd-8202-8398fa97b205", "Responsable", "RESPONSABLE" },
                    { "2", "0404bb6d-96de-4681-82b3-bcb5733c0adf", "Pilote", "PILOTE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bfd621df-08a9-4e32-9976-bb31b6350660", "M.Ney@jitc.com", false, "Mo", false, null, "Ney", "M.NEY@JITC.COM", "MONEY", "AQAAAAEAACcQAAAAEG4dPiUnzaW2a3ANPnkmJFPZ+XeXjD3DWjVxMcsvG3O7/kA3V0yYvJKlyrthCXMKsA==", null, false, "38e6b073-be5f-4bff-b564-6efc68a722bd", false, "MoNey" },
                    { "2", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7391aa83-072d-40ac-bf6e-aebedc52eb27", "D.Balav@jitc.com", false, "Daniele", false, null, "Balav", "D.BALAV@JITC.COM", "DANIELEBALAV", "AQAAAAEAACcQAAAAELgvc7vEdEI8oRXc0iPXD7jpXrIZw2/k1cILLPyWWZYkR8DtGJCNhxwuCrX3K1b+Nw==", null, false, "5a863584-3d98-43c3-9746-367c8d90b5fd", false, "DanieleBalav" },
                    { "3", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "237241f0-989b-46ae-9f58-ec3225cf021a", "T.Sabine@jitc.com", false, "Thierry", false, null, "Sabine", "T.SABINE@JITC.COM", "THIERRYSABINE", "AQAAAAEAACcQAAAAEM7m5qZCPNA9ADmMUReIsnx1zDLNXz+EMOe/ljSEMUJz0VO9gH3tzZA230/gu+oWHQ==", null, false, "6ce9ce10-e137-41fa-b623-b1dd0dd6f94b", false, "ThierrySabine" },
                    { "4", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4f555741-7712-4a3c-af5d-ba7ebaf86f6f", "E.Coptere@jitc.com", false, "Eli", false, null, "Copetre", "E.COPTERE@JITC.COM", "ELICOPTERE", "AQAAAAEAACcQAAAAEBEVLbjM/iWfIb/JbFIY7T6Y1lrttIvzthP6hN5TeRq2gHRkG68SLf2veFW8J5BdgQ==", null, false, "677be91e-3d05-4751-88f7-f7d6a7476f51", false, "EliCoptere" },
                    { "5", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "05882b94-95a7-4f8c-9502-878a2e414a30", "JobKom@jitc.com", false, "Job", false, null, "Kom", "JOBKOM@JITC.COM", "JOBKOM", "AQAAAAEAACcQAAAAENrMnuMV/x81KdY95D6DSfFtCg03hDd7cMYpAnpvuT5Qr9UVcwWIBFKeIhq6Ds7pLQ==", null, false, "4d647222-14ff-48c1-896e-f988da79cd7a", false, "JobKom" },
                    { "6", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5501706c-0e77-4bb0-8f92-4e316d045dcf", "BlaisePascal@jitc.com", false, "Blaise", false, null, "Pascal", "BLAISEPASCAL@JITC.COM", "BLAISEPASCAL", "AQAAAAEAACcQAAAAEGy6wuL7IIZgPvwc8I7eC3Uq0E/0VX1fX1AenjcUmqImnwAq09NSVfjo+t2KbYhSgQ==", null, false, "42fc187a-f115-412f-9611-2026f90c5cd3", false, "BlaisePascal" },
                    { "7", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6c2733c4-5725-4619-8f08-0a6ee81d099c", "JeanPierre@jitc.com", false, "Jean", false, null, "Pierre", "JEANPIERRE@JITC.COM", "JEANPIERRE", "AQAAAAEAACcQAAAAEOC0MpFsTXrb/e91ENq6FCNyVEKQizTpRo8jDB/kT33LlXE/vJ0C7H9Hs1wJxuVRhQ==", null, false, "43ef880b-b9cf-401e-a3a3-956771aa792e", false, "JeanPierre" }
                });

            migrationBuilder.InsertData(
                table: "ModifVol",
                columns: new[] { "Id", "VolModifs" },
                values: new object[,]
                {
                    { 1, "[\"{\\\"IdVol\\\":1,\\\"Vol\\\":\\\"Liège - Bruxelles\\\",\\\"Depart\\\":{\\\"Id\\\":1,\\\"Nom\\\":\\\"Liège\\\",\\\"Latitude\\\":50.63583079,\\\"Longitude\\\":5.439331576},\\\"Arrive\\\":{\\\"Id\\\":2,\\\"Nom\\\":\\\"Bruxelles\\\",\\\"Latitude\\\":50.90082973,\\\"Longitude\\\":4.483998064},\\\"DepartPrevue\\\":\\\"2022-08-01T08:02:00\\\",\\\"ArrivePrevue\\\":\\\"2022-08-01T10:02:00\\\",\\\"DepartReelle\\\":null,\\\"ArriveReelle\\\":null,\\\"NombrePlace\\\":10,\\\"NombrePlaceDispo\\\":0,\\\"Pilote\\\":null,\\\"Appareil\\\":{\\\"Id\\\":1,\\\"Nom\\\":\\\"Eurocopter AS 355 F1/F2 Ecureuil III\\\",\\\"Description\\\":\\\"\\\",\\\"Capacite_Cab\\\":5,\\\"Vitesse\\\":220.0,\\\"Moteur\\\":\\\"Deux turbines du modèle de Rolls Royce 250-C20F\\\",\\\"Statut\\\":false,\\\"Vols\\\":[]},\\\"Recurrence\\\":null,\\\"Reservation\\\":null,\\\"Reservations\\\":null,\\\"vols\\\":null}\"]" },
                    { 2, "[\"{\\\"IdVol\\\":2,\\\"Vol\\\":\\\"Bruxelles - Liège\\\",\\\"Depart\\\":{\\\"Id\\\":2,\\\"Nom\\\":\\\"Bruxelles\\\",\\\"Latitude\\\":50.90082973,\\\"Longitude\\\":4.483998064},\\\"Arrive\\\":{\\\"Id\\\":1,\\\"Nom\\\":\\\"Liège\\\",\\\"Latitude\\\":50.63583079,\\\"Longitude\\\":5.439331576},\\\"DepartPrevue\\\":\\\"2022-08-07T08:02:00\\\",\\\"ArrivePrevue\\\":\\\"2022-08-07T10:02:00\\\",\\\"DepartReelle\\\":null,\\\"ArriveReelle\\\":null,\\\"NombrePlace\\\":10,\\\"NombrePlaceDispo\\\":0,\\\"Pilote\\\":null,\\\"Appareil\\\":{\\\"Id\\\":1,\\\"Nom\\\":\\\"Eurocopter AS 355 F1/F2 Ecureuil III\\\",\\\"Description\\\":\\\"\\\",\\\"Capacite_Cab\\\":5,\\\"Vitesse\\\":220.0,\\\"Moteur\\\":\\\"Deux turbines du modèle de Rolls Royce 250-C20F\\\",\\\"Statut\\\":false,\\\"Vols\\\":[]},\\\"Recurrence\\\":null,\\\"Reservation\\\":null,\\\"Reservations\\\":null,\\\"vols\\\":null}\"]" },
                    { 3, "[\"{\\\"IdVol\\\":3,\\\"Vol\\\":\\\"Liège - Oostende\\\",\\\"Depart\\\":{\\\"Id\\\":1,\\\"Nom\\\":\\\"Liège\\\",\\\"Latitude\\\":50.63583079,\\\"Longitude\\\":5.439331576},\\\"Arrive\\\":{\\\"Id\\\":3,\\\"Nom\\\":\\\"Oostende\\\",\\\"Latitude\\\":51.193165894,\\\"Longitude\\\":2.858163234},\\\"DepartPrevue\\\":\\\"2022-08-15T08:02:00\\\",\\\"ArrivePrevue\\\":\\\"2022-08-15T11:02:00\\\",\\\"DepartReelle\\\":null,\\\"ArriveReelle\\\":null,\\\"NombrePlace\\\":5,\\\"NombrePlaceDispo\\\":0,\\\"Pilote\\\":null,\\\"Appareil\\\":{\\\"Id\\\":2,\\\"Nom\\\":\\\"Bell 206 JetRanger\\\",\\\"Description\\\":\\\"\\\",\\\"Capacite_Cab\\\":4,\\\"Vitesse\\\":190.0,\\\"Moteur\\\":\\\"Une turbine du type Rolls Royce 250-C20B\\\",\\\"Statut\\\":false,\\\"Vols\\\":[]},\\\"Recurrence\\\":null,\\\"Reservation\\\":null,\\\"Reservations\\\":null,\\\"vols\\\":null}\"]" },
                    { 4, "[\"{\\\"IdVol\\\":4,\\\"Vol\\\":\\\"Bruxelles - Charleroi\\\",\\\"Depart\\\":{\\\"Id\\\":2,\\\"Nom\\\":\\\"Bruxelles\\\",\\\"Latitude\\\":50.90082973,\\\"Longitude\\\":4.483998064},\\\"Arrive\\\":{\\\"Id\\\":4,\\\"Nom\\\":\\\"Charleroi\\\",\\\"Latitude\\\":50.455998176,\\\"Longitude\\\":4.45166486},\\\"DepartPrevue\\\":\\\"2022-08-16T08:02:00\\\",\\\"ArrivePrevue\\\":\\\"2022-08-16T10:02:00\\\",\\\"DepartReelle\\\":null,\\\"ArriveReelle\\\":null,\\\"NombrePlace\\\":15,\\\"NombrePlaceDispo\\\":0,\\\"Pilote\\\":null,\\\"Appareil\\\":{\\\"Id\\\":3,\\\"Nom\\\":\\\"Robinson R44 Raven II\\\",\\\"Description\\\":\\\"\\\",\\\"Capacite_Cab\\\":3,\\\"Vitesse\\\":190.0,\\\"Moteur\\\":\\\"Un piston du type Lycoming modèle IO-540\\\",\\\"Statut\\\":false,\\\"Vols\\\":[]},\\\"Recurrence\\\":null,\\\"Reservation\\\":null,\\\"Reservations\\\":null,\\\"vols\\\":null}\"]" },
                    { 5, "[\"{\\\"IdVol\\\":5,\\\"Vol\\\":\\\"Charleroi - Bruxelles\\\",\\\"Depart\\\":{\\\"Id\\\":4,\\\"Nom\\\":\\\"Charleroi\\\",\\\"Latitude\\\":50.455998176,\\\"Longitude\\\":4.45166486},\\\"Arrive\\\":{\\\"Id\\\":2,\\\"Nom\\\":\\\"Bruxelles\\\",\\\"Latitude\\\":50.90082973,\\\"Longitude\\\":4.483998064},\\\"DepartPrevue\\\":\\\"2022-08-17T08:02:00\\\",\\\"ArrivePrevue\\\":\\\"2022-08-17T10:02:00\\\",\\\"DepartReelle\\\":null,\\\"ArriveReelle\\\":null,\\\"NombrePlace\\\":6,\\\"NombrePlaceDispo\\\":0,\\\"Pilote\\\":null,\\\"Appareil\\\":{\\\"Id\\\":3,\\\"Nom\\\":\\\"Robinson R44 Raven II\\\",\\\"Description\\\":\\\"\\\",\\\"Capacite_Cab\\\":3,\\\"Vitesse\\\":190.0,\\\"Moteur\\\":\\\"Un piston du type Lycoming modèle IO-540\\\",\\\"Statut\\\":false,\\\"Vols\\\":[]},\\\"Recurrence\\\":null,\\\"Reservation\\\":null,\\\"Reservations\\\":null,\\\"vols\\\":null}\"]" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "2", "3" },
                    { "2", "4" }
                });

            migrationBuilder.InsertData(
                table: "Vol",
                columns: new[] { "Id", "AeroportArriveId", "AeroportDepartId", "AppareilId", "Distance", "HeureArrivePrevue", "HeureArriveReelle", "HeureDepartPrevue", "HeureDepartReelle", "ModifDate", "ModifVolId", "NombrePlace", "PiloteId", "Raison", "Recurrence", "Retard" },
                values: new object[,]
                {
                    { 1, 2, 1, 1, 29.515449800117239, new DateTime(2022, 8, 1, 10, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 1, 11, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 1, 8, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 1, 8, 2, 0, 0, DateTimeKind.Unspecified), true, 1, 10, "2", "Mauvais temps", null, true },
                    { 2, 1, 2, 1, 29.515449800117239, new DateTime(2022, 8, 7, 10, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 1, 10, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 7, 8, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 1, 8, 2, 0, 0, DateTimeKind.Unspecified), true, 2, 10, "2", null, null, false },
                    { 3, 3, 1, 2, 49.515449800117239, new DateTime(2022, 8, 15, 11, 2, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 8, 15, 8, 2, 0, 0, DateTimeKind.Unspecified), null, true, 3, 5, "3", null, null, false },
                    { 4, 4, 2, 3, 49.515449800117239, new DateTime(2022, 8, 16, 10, 2, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 8, 16, 8, 2, 0, 0, DateTimeKind.Unspecified), null, true, 4, 15, "4", null, null, false },
                    { 5, 2, 4, 3, 59.515449800117239, new DateTime(2022, 8, 17, 10, 2, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 8, 17, 8, 2, 0, 0, DateTimeKind.Unspecified), null, true, 5, 6, "3", null, null, false }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "UserId", "place", "volId" },
                values: new object[,]
                {
                    { 1, "5", 5, 1 },
                    { 2, "6", 10, 2 },
                    { 3, "5", 5, 3 },
                    { 4, "7", 10, 4 },
                    { 5, "6", 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_volId",
                table: "Reservation",
                column: "volId");

            migrationBuilder.CreateIndex(
                name: "IX_Vol_AeroportArriveId",
                table: "Vol",
                column: "AeroportArriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Vol_AeroportDepartId",
                table: "Vol",
                column: "AeroportDepartId");

            migrationBuilder.CreateIndex(
                name: "IX_Vol_AppareilId",
                table: "Vol",
                column: "AppareilId");

            migrationBuilder.CreateIndex(
                name: "IX_Vol_ModifVolId",
                table: "Vol",
                column: "ModifVolId");

            migrationBuilder.CreateIndex(
                name: "IX_Vol_PiloteId",
                table: "Vol",
                column: "PiloteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Vol");

            migrationBuilder.DropTable(
                name: "Aeroport");

            migrationBuilder.DropTable(
                name: "Appareil");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ModifVol");
        }
    }
}
