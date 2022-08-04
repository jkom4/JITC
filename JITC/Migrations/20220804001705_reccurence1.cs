using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class reccurence1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Recurrence",
                table: "Vol",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recurrence",
                table: "Vol");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ecbfb05a-22d1-4205-952b-6d72245e4366");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8dab1a28-2f72-4121-b7d3-cff6226aae76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f37a638-1b0d-4a98-b688-d4f5de598536", "AQAAAAEAACcQAAAAENpeVlkiZF4fSmAwPlaD38KXZTEyMxhU7bM/JzOx/mw/e5xmPJfnMQaOKNmmi88tNg==", "fb6c759e-9af0-4287-8ba9-6d9992fab183" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b8d54f4-cc1a-47f9-bdde-5a5fef10b081", "AQAAAAEAACcQAAAAEMi4KC7/DZMwP5PRzVU781EJQ1a/jq6HadO5Zt2RX6f8jNP4gm2Ekc8BDcLPXTp+lQ==", "69a967cc-3185-40c0-8cc0-393e0250d3a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "372ce3e6-e02c-483f-bebd-b40924440087", "AQAAAAEAACcQAAAAEDzMkJ7wgCiAZGvrWf253Yrp0GbVUWS4iup5IM93aBYy0wQcPZq/qhx2CPEGq4vA6Q==", "0d274564-2677-42dd-b15f-720c24546ab0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1996ce2-ed89-4ec8-9578-d13620263b79", "AQAAAAEAACcQAAAAEJd4nlSx8aWZ0r3gBNa0CT1WwEnw65Id6OQKsg9fg3tvE42KUDJ7xP7tLt8JeV0K7w==", "28e6d842-de39-45ce-821e-1bfaa206d25d" });
        }
    }
}
