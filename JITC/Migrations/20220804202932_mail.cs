using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class mail : Migration
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
                value: "42b6cad2-1160-4475-be51-b364ec77163f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d4a0c4ec-f16a-4b27-8295-19b5c99eaae3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7220680-f1cb-46d9-a4f4-30a687f641a8", "AQAAAAEAACcQAAAAECnSf0vf4wNYewJeGdLr1L5daOcGRpwgW/9/no7aIWaBCkYTlqvmhSeirtvbFtXNYQ==", "2e8d78c2-6cf1-43cf-8145-1f3a61c7a428" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "136c73cb-01b7-40f5-9b16-edb500fdbb32", "AQAAAAEAACcQAAAAEKYz21Ln6Dxi8MLpfuFmou4YSZbN7kmjAWvl6MkSBQPc+9DcOGwjdepr72ISjW6KfA==", "43be8e38-3b72-4e4c-9626-61a2c2de5aa3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "457734d2-54e4-4f6b-8fd8-19b7d448cabe", "AQAAAAEAACcQAAAAELyLilzh+TYzzHsQXBG1ywLflBEaoGpvUw4zEoamUtGdCRJJdIxfLyx8fz6XbhZ4aQ==", "2da79502-895a-42c7-935d-cc0808403ec6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "602310c0-c391-45a1-8e87-a080baf2a46e", "AQAAAAEAACcQAAAAEEy96jjaeD2OhJN8nPKClE6u5zmU2/IaAIrFkvfBWnmiwr1NXSFkFM/SwInV02SqIg==", "2c3d1755-67ec-488a-891c-5743a09ea712" });
        }
    }
}
