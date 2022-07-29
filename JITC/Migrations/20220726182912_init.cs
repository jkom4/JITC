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
                        .Annotation("SqlServer:Identity", "1, 1")
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
                    AppareilId = table.Column<int>(type: "int", nullable: true),
                    Recurrence = table.Column<int>(type: "int", nullable: false),
                    Retard = table.Column<bool>(type: "bit", nullable: false),
                    Raison = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifVolId = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "Id");
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
                    { 1, 5, "", "deux turbines du modèle de Rolls Royce 250-C20F", "Eurocopter AS 355 F1/F2 Ecureuil III", false, 220f },
                    { 2, 4, "", "une turbine du type Rolls Royce 250-C20B", "Bell 206 JetRanger", false, 190f },
                    { 3, 3, "", "un piston du type Lycoming modèle IO-540", "Robinson R44 Raven II", false, 190f }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "f29ecc48-a325-4359-9a29-9443097005fd", "Responsable", "RESPONSABLE" },
                    { "2", "3d687ea5-4c60-4a7e-af3d-d00de850c48a", "Pilote", "PILOTE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f647761a-4f35-4862-a5c0-9f20d11e62c8", "M.Ney@jitc.com", false, "Mo", false, null, "Ney", "M.NEY@JITC.COM", "MONEY", "AQAAAAEAACcQAAAAEFK8Dk4vb2meVqcHkC9QxCl5juaFt1NKo/crVKOB7M8qWnqnNIqnD82YpAyOavrnpQ==", null, false, "19fe976d-7c57-44aa-aa79-3c2bd146e770", false, "MoNey" },
                    { "2", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a6e8637b-c046-4c80-b1ad-6ee64924ee27", "D.Balav@jitc.com", false, "Daniele", false, null, "Balav", "D.BALAV@JITC.COM", "DANIELEBALAV", "AQAAAAEAACcQAAAAEKRyc6adGfANAmHZ8xNAp4fV/YRAiXuVsxY1JRmOoe6Jflt0YvfPDpa4SvvTRMJHRA==", null, false, "01d78841-f34c-4958-8a03-3dc8d1e63359", false, "DanieleBalav" },
                    { "3", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4ae4ad02-0493-42c4-942a-5ad944bfc07a", "T.Sabine@jitc.com", false, "Thierry", false, null, "Sabine", "T.SABINE@JITC.COM", "THIERRYSABINE", "AQAAAAEAACcQAAAAEL5kcH2PP9RVbMz+QlkFFGB2j0O/hUFJtt5NVejYaXvDHY9Ulz7fX2cwhzHiuSGVVA==", null, false, "3fdac64d-0c5e-4193-a32e-537fb7d8345e", false, "ThierrySabine" },
                    { "4", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b57446ab-a1f7-4543-89b2-c91609adb24f", "E.Coptere@jitc.com", false, "Eli", false, null, "Copetre", "E.COPTERE@JITC.COM", "ELICOPTERE", "AQAAAAEAACcQAAAAEErxccuLB00g6H044LnKeHGEq/gDYH0pXOwXMZwPrRMMrJLdNCxbn3JpXhrH8JrCzA==", null, false, "d3c56cb5-fe08-46fa-815e-5934bf6cbf37", false, "EliCoptere" }
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
                name: "Vol");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
