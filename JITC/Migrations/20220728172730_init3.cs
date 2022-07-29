using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "109027dd-6ffb-4e7e-844a-e88838ceb7f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "56a7ce23-f7c4-47b2-8855-14ccf293063b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa390dd3-9da7-44c8-a969-3272e18eb6e8", "AQAAAAEAACcQAAAAEK49ZlGTEt71J0gwQDYMvWZeud8otomKf+Gf4Dk+nO9AGVfQPdRnmWNDYJaPLKTUGA==", "ae8386c4-2ec7-4ee4-b627-90de9aa6f359" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05a6eb80-91bf-4adc-a3b8-5eddf40e60b3", "AQAAAAEAACcQAAAAEFV59StJwqH+B+83BQOddlJ4lgyhMmWV2Dy/lr94csyX0xRqgeSPdw3iLXZTI8DnEw==", "fd2642c7-1277-42d9-ae83-363c269ee027" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40b60857-a57e-4613-b837-df2060a31434", "AQAAAAEAACcQAAAAEMauJ0deJVbkerpiXP8ztTU2o75ZpGgHmriPf/HYtevwQpbTjTv9y2u2/oBYPtZy2A==", "fb343155-f748-4dfe-b6b3-ec87485bf2aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "632fb828-3fb2-49b3-a3c5-da79870d824f", "AQAAAAEAACcQAAAAENv9DETwYsnus/HJCjZZQSOMD37kx0BgEqsQHQyKY4fzfdTjeOVoaked7fiqPtDNFw==", "ff6a9da1-f6ed-46bf-b780-5615cb45ebb9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
