using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9565f44e-872e-4f1c-8c46-ccb9cd0aca83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8733d9db-c8cd-4c29-874a-3c98b7471485");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ff60954-c69c-43ee-869b-ca15cba7e652", "AQAAAAEAACcQAAAAENheeUmCd4N49G9OKL57nptvIskBt26wFiVzfCNkjvX9kPn6ABXrCES2Z4OK+QsEkA==", "21c77918-73af-4788-ac5b-634af09e2c2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed8b0e2e-b3d9-42c6-b7fb-ddc62e238cec", "AQAAAAEAACcQAAAAEF0yMWHUOIcQ/7vCJSJHCDGxXcsy8MaqP7bT9APM7B2izPbepbPuLyb+mKs/ScgdfA==", "e723e207-27f3-4f47-962d-a48f7440952a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09f8542c-e836-4c1a-8be7-db37f2fb6fcb", "AQAAAAEAACcQAAAAELgI8B+Yi9CF85lpKF4x6gHAFSx+6J3FM0i3VQ8PlhMuvh19WdwvEizIPbOZnhfe9w==", "4de15ab3-708d-483a-8dc3-38e2386f9fa6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d25cbafc-6a01-4018-a4d3-abae17f5860f", "AQAAAAEAACcQAAAAEG4xRpUjBNSCmqzq4rTRIHNUWRXQamZ2SZmZPP04kmLMGs02eV9iRyrzuUx+bRvdfg==", "16735254-052c-42fa-98de-1f529922c9bb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0eeddd42-c992-4c4b-b67f-72f3e0dc2c8a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "cf22468e-2926-4a0e-848e-b358034a2933");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c363cc0-9d91-4867-89a5-1cdc30fa940c", "AQAAAAEAACcQAAAAEJXGr9ObEMNizo6OW3IF8Meg1Wjj9StpE2QYWPknaHTXRKrIHYgtQNAbzkmVJ/lhVw==", "368a616c-0744-4921-9a5c-f8a4c0be9cd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22d4255a-f998-4a14-adaf-7399ab88c009", "AQAAAAEAACcQAAAAEMOHOdZy90m8mKrnEIZncNkuLrV3gfSbX+GcoCKxBABuJn1SFFu5G7k/TkgUW1VvWA==", "f4df017b-63b6-4d6d-93b3-9bf4413210c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e62a9d51-3789-497a-abcb-134978a86006", "AQAAAAEAACcQAAAAEJ/b62/QIaj7BispSFDcZ2iVV5yxcRHVVJC9T0Ofcrx9Fm8/e2KpqURbbi6Yek/9cw==", "ab8d32ea-1aa4-45a1-b237-e0e78559d916" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "723a4cde-061f-4e8a-92cd-34b55c5496c7", "AQAAAAEAACcQAAAAEBm4bCmNnHsAjeMq37sTWmqSTNTiGCvYzHQ91MOADfK8LXK1UB+UJRr+Cws2+xXyzw==", "d5e243cb-09a5-412e-9682-0d6947f3af1e" });
        }
    }
}
