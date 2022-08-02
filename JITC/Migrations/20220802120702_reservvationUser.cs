using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class reservvationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6e3db67b-f035-4096-980f-cdb84e32c5c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5b2d6528-6aa5-4039-8ff4-235cc5e6c38a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f226445-efa0-476f-96f8-a32e7fc5635f", "AQAAAAEAACcQAAAAEBYvfyfJHjhCyeaqh5xEFaq2Nz9iJtiCOH+Iw1EO8Qalr9BwxeB5bkjsD+FwaEsMBg==", "9d6ca759-60fd-4a49-84e6-f1b6030413f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa998565-92e2-449c-b047-d6844f721951", "AQAAAAEAACcQAAAAEBBUd9XQc5Z/9M2a/fuGK4MHNzetD+bFURgg8Nq4KTFr6gh9nIdaB/WZ+pLztwBvqg==", "d7ddeac4-5a39-4bbf-977a-1a7debb14ec1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "328cbb2b-1ecc-42a4-ae4f-a06f39535cb8", "AQAAAAEAACcQAAAAEI032NNoIPgIpFa5lhJW3zIyxqZtZvhSMQGDiFzYp90/3y0OGybS37rx+nqfxD99SA==", "52159a91-dda9-4258-a7da-e431ab259bbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cd5b9d8-d943-4a65-9668-5ff1331369b1", "AQAAAAEAACcQAAAAEJR3q0aN50l9WrAycqcYjIRsWA2KdwhTyNiV/g/fBfZKAO2tbyAKO9nA0TURjCetkQ==", "3053c97a-dede-4920-a1fd-eca33e672659" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_UserId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservation");

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
        }
    }
}
