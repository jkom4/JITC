using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class newi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ModifDate",
                table: "Vol",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1fb58b5b-2b88-4bf1-a75f-02d52ac70d01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0c8cd044-2cd6-4f81-9382-1ed23c514389");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e99f6dd1-0411-413b-a635-d9f103cbf5be", "AQAAAAEAACcQAAAAEJFzcKoE/5pSlp9BsVrSy+bPZiFKdmBwtDot4w0G4yUS4n3JgK2vCUtHpZnjeRxtHA==", "02ad75b7-286f-4b39-95d4-4600d630256d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51957ab5-1fd4-4b18-9851-5acbbea23f27", "AQAAAAEAACcQAAAAEFy7iVZdtkm3EMe5dN0Qe7ELRSo+V0aO9sI/CMiaZcgoa9OFX3mFbhm9IWTcDVgrtw==", "8a40540f-d5df-4c91-9c35-a743ac6f4022" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a5015ba-cb60-4aac-a40c-15da7b82dd6e", "AQAAAAEAACcQAAAAEFakq+Go468tz8oWoSnjNH3Kj3aR5XPnB0W8zq1RnemrCHc5CQEImRnCh2Z2WNRfTg==", "1e05b768-e370-4726-b313-d02ee1783fd9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2acd78a6-05ed-447d-99c9-3d826e98add5", "AQAAAAEAACcQAAAAEJRJD9ainIk7SYMT96+BoSxHeCv4F9fYOaeGvJCh9BmMxgmj0wSANX/6TPHwGwdSrQ==", "aed6f51f-7001-45ac-b04a-2c0160decc4e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "Vol");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7bad369a-3b1a-4ea4-8933-6fb134f3c4a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "50f41362-d706-4c82-b3b9-e52e22b9a9c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7efaeeda-97e4-455a-894e-c7df096a2f95", "AQAAAAEAACcQAAAAEMmtMHjabjg9XIS9L6KGt0HxtzEFfg9J5d4QtWDUoYQtJfBcxfFOIU474pv3vjDjbg==", "e9fc8e3a-4eac-43a2-a97d-7eecebb207d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60a69879-f31a-4ba3-89e8-51a772d9a559", "AQAAAAEAACcQAAAAELpKXPMWx4bW/u4ibp1aSk2yMaLkAYqORyCwOifntPsIXcEbrDp9ps8S4yitOWWeHA==", "597273ea-052f-4d5a-b017-b22c930fabd0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e0cb82d-b7b0-49df-8c09-600dc3deefa4", "AQAAAAEAACcQAAAAEBqNiPKcZwGBOZpVKBKJUM5fBR8kOqiNZmNJaFcWY4FO5D5lqTEKpkBrdNcJ+isb5Q==", "e0e5e5d2-291b-485d-aa0d-c98ff736301c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12838edc-ba20-4fc9-8c63-0f92afb25fbc", "AQAAAAEAACcQAAAAEIssg2cWqKE0eX29tCYYjtSbr5CywNNXBz9yVfp1agVX0qsL83UOhrQ0chjFFgRExA==", "f817a84b-d3d9-4918-8bc9-f88eeeb31c12" });
        }
    }
}
