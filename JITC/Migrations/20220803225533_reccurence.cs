using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class reccurence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Recurrence",
                table: "Vol",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "28a25804-325c-4e30-8ad5-b59cb03dcfc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "383fc3d4-3c30-4708-bcbf-0169df6ec82a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99193783-2351-4d5d-b62a-0ab78d180302", "AQAAAAEAACcQAAAAEAonfFh1FBmaxnRvEoDYwq7LT5amFqDhBXeiX1ho63MIa53RnjB0eosSRqsNJPlhGQ==", "124a5455-86dc-4a35-8412-919d7767d589" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4837413-88df-4bae-9915-08982f0259b0", "AQAAAAEAACcQAAAAEGs0VHcXuQhhYRgRcHK//Ew8ECCpPPg4LEqZVuXl/9HeI9y19UHniHVuWPZfeg8khg==", "00d889df-f590-427a-be5d-39b166ab8db1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "091d4bea-728f-42f9-b2b6-ceabe21b5694", "AQAAAAEAACcQAAAAEAc4lEWc6X9jGkvq+Nvx3gZQOGZ1hq7dlKef4BOF4gfEO7paVx58F19rmUOT7kIBDA==", "176cf282-2eea-4f28-9c7b-21ec40e67cb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3c61fb5-fb5d-4cc2-8a25-d8e64e798ebf", "AQAAAAEAACcQAAAAEFvBp+uy6syDes29WB9Y8W7HXfTsEpSa573+iWllTj+DYlwy0lmkpoiLUGnzvAlFBw==", "15503496-2002-443d-9459-f9f8276b31a8" });
        }
    }
}
