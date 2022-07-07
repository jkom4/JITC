using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class Appareil_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Appareil",
                columns: new[] { "Id", "Capacite_Cab", "Description", "Moteur", "Nom", "Statut", "Vitesse" },
                values: new object[,]
                {
                    { 1, 5, "", "deux turbines du modèle de Rolls Royce 250-C20F", "Eurocopter AS 355 F1/F2 Ecureuil III", false, 220f },
                    { 2, 4, "", "une turbine du type Rolls Royce 250-C20B", "Bell 206 JetRanger", false, 190f },
                    { 3, 3, "", "un piston du type Lycoming modèle IO-540", "Robinson R44 Raven II", false, 190f }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9a131796-191e-47c9-8e6e-462b1a957542");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8cf6a114-1cc1-40f6-a40a-f6c4ee980cb2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fea222e4-2cfd-4724-af3c-9c92f957bf1b", "AQAAAAEAACcQAAAAEOmtIK678svYWBpBOkBzqlgeJtS+1evPmydPYWVIQUQReDcpIlViPCgkoX2UrLsfBQ==", "706b3b2a-d655-4297-8125-dab799bf6e75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cd6e08f-714b-4b6b-8c1d-9a1103b04dbc", "AQAAAAEAACcQAAAAEM4XFMJQTEw0Yzi4pDvtDL3hH77CPMqQBjOZW0yxYwjwAKA2YJem2lrJgK2//zhImg==", "7dca8d29-2868-45da-96d2-f789e440d9c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6c4f3fd-6141-4b6c-9f83-f11e21d251e9", "AQAAAAEAACcQAAAAEKKCWURZe9lnYRpxLlLwHhvFLJ1tymnldPzkFvOFlXW6Lia4aBbO/sIq3MSgcEZZXA==", "425c5a30-fc6b-4cd8-a562-acc6ea51d2a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43544d20-0854-4e42-9007-fdcb2e5fc91c", "AQAAAAEAACcQAAAAEBwWuKUGt4HESSopkXDyzsryi6kBZgSxSNZDd1j11IpAp+BCCufs4KGG8RR12mccDg==", "f101a6e0-6c37-4cb2-a0a7-48d5dd379b27" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appareil");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d66ca914-3fdf-4abc-abe1-7a1087e874e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5846e171-9d51-407c-8a7d-1b85c2b08772");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47f5c464-3265-4aa2-8407-4192b788d2cf", "AQAAAAEAACcQAAAAEPrEQMUdnxG3QSGCYIu3aCFqNpsleTa/GwZ6GK+F7XMLjyjrOCGCknC2OhTux5vpkg==", "37a4c566-8886-48ba-b746-a246399700ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d2e4ea7-2a90-403a-b4af-586ee0d28388", "AQAAAAEAACcQAAAAEJSNekQ2H3A9gqWsnyNhQ/aathP/kuGJvSh3GzeM2BMBbU3CTRpTeS5Bnud5HGty9A==", "7301f1d7-6a38-44c7-91e1-9ae6477c8397" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8d966ee-679c-416f-9d03-f75b760c39cd", "AQAAAAEAACcQAAAAEEuMU6IMq27FxkqjGSyxkzCCyvZ9bkZTUZnQ6AEpnUS1l1vC/QaOdn15MvwRVnpsiQ==", "438deeda-a927-44c7-9f2a-800d32b76606" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23ad613a-bf87-4a86-abdb-e6927784b497", "AQAAAAEAACcQAAAAEDOA/akY6dKr4XPiVb4d22T2wPPKQv5JRC7Nyln7niJBG7ZutbMJZUKip8azKnVr7w==", "5c67b440-5ca3-4d8b-868c-e532f34ed654" });
        }
    }
}
