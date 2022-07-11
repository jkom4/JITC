using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class arrive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AeroportArriveId",
                table: "Vol",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a002f7b0-5a05-41d8-82c5-ad8d7027ae35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "11c67c02-1b2d-443e-8aeb-a080a0df22bf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fe748b4-a0e1-49c4-9fec-33c0e41602bc", "AQAAAAEAACcQAAAAEJ5fN9AQXMykiTYZ8Waaw8ZXhFbCvR4K84AXlW3/qcqK8mFtJn/4moqJT6j9AqbrMQ==", "7dede700-d8cd-41d8-9839-a5b1218beea7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86f6aa45-c9b1-4265-bda9-baea0a471507", "AQAAAAEAACcQAAAAEA/7UkoK7zmUFl85aaI2lMCUNeyo9uyTMbBzmgcu77q+bb0ZM8YkIX9bhUymYXIang==", "57ccc8e3-37b6-4d2a-ac34-62f2d35a5b24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a69b4ff3-b119-42e7-8f44-159900781cce", "AQAAAAEAACcQAAAAEKDfd32NMaxiledkFHjX0eBjZGEh4jYkyV+Lh09WfIWBPbfz1eaFdhY1W8zBFW/pcQ==", "6216e06a-6788-4341-85fa-8620fcd162dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87ef9391-ff88-4164-be44-2eb9ae68a4b1", "AQAAAAEAACcQAAAAEGDjgREbQqp5gn/O7/H02+LD92PU8jr7xy94zGHJ8+x5phHHA4370cFAhkbsVs2WCw==", "ca83de9e-12ba-4c63-940e-51aa2b89f37f" });

            migrationBuilder.CreateIndex(
                name: "IX_Vol_AeroportArriveId",
                table: "Vol",
                column: "AeroportArriveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vol_Aeroport_AeroportArriveId",
                table: "Vol",
                column: "AeroportArriveId",
                principalTable: "Aeroport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vol_Aeroport_AeroportArriveId",
                table: "Vol");

            migrationBuilder.DropIndex(
                name: "IX_Vol_AeroportArriveId",
                table: "Vol");

            migrationBuilder.DropColumn(
                name: "AeroportArriveId",
                table: "Vol");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "dffea625-e66a-4e32-a0c8-6d1c236b7149");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7907a098-73ab-4030-9f63-e984ccb4896d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bde2689b-ef39-43db-a455-d694cf1d551c", "AQAAAAEAACcQAAAAEJ/kutf8c+SCyI/cSu5nfT8Y4PHPhX1IEKSZ/L7vxH095ibAFCCHoloJXu0ARLKILg==", "472f7d96-5390-4723-a312-ee462806e09a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38598103-8430-4693-afc3-e66c3766077a", "AQAAAAEAACcQAAAAEIbXM1kthVxJ4bK9HG8yfu1bjE6BwT1gEVZfvJIoMwSB2Ze5WKU58Wlz5WuA7v7haA==", "4f95cdab-a1a7-43b5-babb-0b848a21ba55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "369f6a82-537e-4f7b-9102-4068e43eb65c", "AQAAAAEAACcQAAAAEN0GC0wuPbEws0GnHpplhLzKybPXUuYy9sBcW/36/Z/tS/iKQzklmK2udJoc9tIDvg==", "8d98cd3b-371a-4861-8894-6717614b29c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41ef56bf-356f-4ccc-bd03-8961bc015a5d", "AQAAAAEAACcQAAAAEOodyNR74b2LClNt/Flo84KyweCkar/tehm68uqmJodnqNdwEMkXN8ZFerbH2gymCA==", "ca5090d8-8780-4e70-b514-3617a823dd6f" });
        }
    }
}
