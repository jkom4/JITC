using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "d61e29c8-0e44-4f6e-86cb-38fa230ecf8a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f83e498e-aa2a-4e34-a384-0cb86408e593");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03019e1a-ce4c-4f81-8677-6b16696d77f2", "AQAAAAEAACcQAAAAEJpl988nx7Jl+PNURxC68ResMebsuHLL8ytl6Tmil3A0wnUn341btmYZPkG23IXUCw==", "7bb4c9a3-779d-4eb7-80a3-6be920e3fa2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f2f76c5-4cc0-4e43-bd20-6ae1e72efa52", "AQAAAAEAACcQAAAAEEDJGurx6MJkXP/PT/5yVoCuFO/WlHcfA3waeMsMqHB5xCIzdHK+3rc3PmOU7VopSw==", "f69c4785-6680-4795-92f0-71a8d24c536f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44645ee0-d4de-4904-88f8-16dd45b0b053", "AQAAAAEAACcQAAAAEHlkv9Dk2JG9uHn8HumZuwuel66Q8MN5+igg6cPL21ouaVUJb7TYHQQc3gfcx1TZyg==", "c0f2debe-eb59-4854-a2ec-1cb5726e35ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32b2875e-a6f9-4513-ac5f-9ddbf3ce2cef", "AQAAAAEAACcQAAAAEBBQdNCUNIP5f6ESVZ0j/g4MPFSR7TGESIJDi5GHMj3qO9srF4I5Nhv+CJB5caQdVA==", "ec62fa80-44dc-4959-9bcf-6d9ac7013223" });
        }
    }
}
