using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    volId = table.Column<int>(type: "int", nullable: true),
                    place = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Vol_volId",
                        column: x => x.volId,
                        principalTable: "Vol",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Appareil",
                keyColumn: "Id",
                keyValue: 1,
                column: "Moteur",
                value: "Deux turbines du modèle de Rolls Royce 250-C20F");

            migrationBuilder.UpdateData(
                table: "Appareil",
                keyColumn: "Id",
                keyValue: 2,
                column: "Moteur",
                value: "Une turbine du type Rolls Royce 250-C20B");

            migrationBuilder.UpdateData(
                table: "Appareil",
                keyColumn: "Id",
                keyValue: 3,
                column: "Moteur",
                value: "Un piston du type Lycoming modèle IO-540");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "dde0f56f-08fb-4ff1-b7c9-5a392eaaeca7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8e8df191-79cd-4e40-b956-849c0f24a6c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9b2c07f-018d-4e77-a83b-ed651331b45e", "AQAAAAEAACcQAAAAEHLU2sQ4oOhQ2Up7FXDcgllOnVAZT9fSU/p2pALFKDul62ciVp5DsxuPlMmfzY/8Lw==", "6f892304-2c79-428e-8e16-748b75529c7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87db38db-51df-4fc7-ade8-828ff64281f5", "AQAAAAEAACcQAAAAENfj6Zut4nM7fN8okwVVHKF1wUStF2mH89iK/2a1WM3ggBuWvO7G63mPhiBAvJVm1A==", "cb22dedd-a493-4657-a6ba-570475955965" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36170c4b-3c5b-4310-8f35-a553373b51d2", "AQAAAAEAACcQAAAAELnqNmWiVS0qS7lCXyyjxG36ttG4hW/8k3zpgK4rtqRfRouloi6oV7QcnxihOY16eA==", "a52ca4ed-9cb6-4325-9b4a-99c0f13584c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fefc190-04a5-4023-862f-547f19f7a12c", "AQAAAAEAACcQAAAAEOcF0Km2dINtiZJo/eUd0EKauqLtJeRPHkUpy41fyBTm1F5VwsvGkv8O+3v8sDN2oA==", "96341a0b-2811-4301-8eb4-c1a140ae0f0a" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_volId",
                table: "Reservation",
                column: "volId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.UpdateData(
                table: "Appareil",
                keyColumn: "Id",
                keyValue: 1,
                column: "Moteur",
                value: "deux turbines du modèle de Rolls Royce 250-C20F");

            migrationBuilder.UpdateData(
                table: "Appareil",
                keyColumn: "Id",
                keyValue: 2,
                column: "Moteur",
                value: "une turbine du type Rolls Royce 250-C20B");

            migrationBuilder.UpdateData(
                table: "Appareil",
                keyColumn: "Id",
                keyValue: 3,
                column: "Moteur",
                value: "un piston du type Lycoming modèle IO-540");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e258629d-cf91-4faf-8cfb-ad743adc5729");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "78981e70-27c1-4108-9d0a-bcee84fbfec2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb0b6c43-ba80-4de3-b7a3-faa2b9a38428", "AQAAAAEAACcQAAAAEDOffp+0sHIkhChHgpzu0DdPYDc1Ibf0VsbvnayXKZhZCb47dMljlnm/75ksfJfw+w==", "df29d47b-e23f-4e32-a5dd-a728c30ea3c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8818417e-1da9-4cdc-ab9f-fdc946a192b9", "AQAAAAEAACcQAAAAEJ3/1G9Ei3XrhT31UrBcEtshRN2QhIL0CP4WJ7TM6I7Cbe/NYC6lAEw5ZjaJXqVP7A==", "ba355130-0435-4e9f-8670-8d826387e5c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c7cf286-c0a1-426d-bcef-2f8899b2b512", "AQAAAAEAACcQAAAAEEEDpGMQmuGn89eZ1lAreHS1UizTk6+Xcr2hm0FEqDh5KUkm44MOWYea+M5QMElTJw==", "9cb47da6-6cd5-4f3d-b562-44db77078bbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4926ebba-e18b-4850-9307-c992b4152c0f", "AQAAAAEAACcQAAAAEMEGnKfrYRmkzQ1zjwyiElsNk7kaPus/TgOzg4xqqXbO1Gue1CI1VbFq8yuHcPeaRw==", "db65f5de-d19c-45db-a2cf-fd1d93175c28" });
        }
    }
}
