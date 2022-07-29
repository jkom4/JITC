using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VolModifs",
                table: "ModifVol",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "87cef9e6-3c1e-41f0-8d75-cd75ff28ea63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "67182286-b0a4-4c3e-aa88-c7f973592a58");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f34fabb-9640-41f3-8e25-7a3530428383", "AQAAAAEAACcQAAAAECbLv91mlfcf38+CSLMdtVclAIrmlA8WoJNXJ9xwiMjbOFs/jqnFLYfkRETLVpFf9g==", "358ab633-c21a-4e46-b4c0-3208f1e9af37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1af6355-170d-43e2-9e40-a552694002e8", "AQAAAAEAACcQAAAAEK+lliPMNCOGYMSOxVkGT/f416Vc/EJbA4iD+86JunzCaUpyWYPotD6HUvVZhnxt/w==", "04b94cf1-1017-4a01-a1c1-e8e4525d61f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58dfef24-75ef-446b-a6bb-702f0c764aa0", "AQAAAAEAACcQAAAAEE6GJ5LH1qN0ycfUqsy8KWlfdcIKDzpvmw95JoA+N/1YFgOUHv5kTw0cuwvmLp/maw==", "fc071c6a-0c90-4ebc-9091-5c38c142ea09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b660e46c-ba93-4147-9624-20beb57a50ec", "AQAAAAEAACcQAAAAEFQijEypZFj27E8AEgWzKSBm8dS4EbHeblEDKKgA0HNefg4oJfotAS9pMmDfcCEWpg==", "e9ae0cf8-ee46-4f8d-b303-fcf0aba3c77a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolModifs",
                table: "ModifVol");

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
    }
}
