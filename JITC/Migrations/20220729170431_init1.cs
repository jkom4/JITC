using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e258629d-cf91-4faf-8cfb-ad743adc5729");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "78981e70-27c1-4108-9d0a-bcee84fbfec2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb0b6c43-ba80-4de3-b7a3-faa2b9a38428", "AQAAAAEAACcQAAAAEDOffp+0sHIkhChHgpzu0DdPYDc1Ibf0VsbvnayXKZhZCb47dMljlnm/75ksfJfw+w==", "df29d47b-e23f-4e32-a5dd-a728c30ea3c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8818417e-1da9-4cdc-ab9f-fdc946a192b9", "AQAAAAEAACcQAAAAEJ3/1G9Ei3XrhT31UrBcEtshRN2QhIL0CP4WJ7TM6I7Cbe/NYC6lAEw5ZjaJXqVP7A==", "ba355130-0435-4e9f-8670-8d826387e5c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c7cf286-c0a1-426d-bcef-2f8899b2b512", "AQAAAAEAACcQAAAAEEEDpGMQmuGn89eZ1lAreHS1UizTk6+Xcr2hm0FEqDh5KUkm44MOWYea+M5QMElTJw==", "9cb47da6-6cd5-4f3d-b562-44db77078bbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4926ebba-e18b-4850-9307-c992b4152c0f", "AQAAAAEAACcQAAAAEMEGnKfrYRmkzQ1zjwyiElsNk7kaPus/TgOzg4xqqXbO1Gue1CI1VbFq8yuHcPeaRw==", "db65f5de-d19c-45db-a2cf-fd1d93175c28" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1d424a84-a186-4a88-a6dc-7a839967ea40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "16326b16-13fc-46f2-ae9c-3f82c5aba5f9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3a757e3-cdc9-48e5-9471-9485c7bf1932", "AQAAAAEAACcQAAAAEADdA9bguwCpCOvtakSjzpQOeAGe9BeEKUknG6nXYAnPSj51dqgSRKJSYGUI8Iur3g==", "34977647-bc69-47a1-9e38-575deaf88b04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c89f7ca-1546-4b78-83fc-3d2db076f680", "AQAAAAEAACcQAAAAEItyTsmpg2P8Ub/aEKk8hD0WrrBOcRifxgDvkruZ4VGrz9/qF4ydcRUevm921aRuSg==", "4cf42ea1-9686-4646-8073-c3e98050184a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc41a135-e879-4040-8208-c2de416f443e", "AQAAAAEAACcQAAAAEOtbQEVzo05DrbVSzUoEzZX2nJxCtkLDB8RxRc2dvZ/qLU2wAPoAgdcrmR6LrrWyeg==", "662ff89a-8b95-4140-80da-a82448cf11c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1be088be-2601-4855-b7de-498fbfe6e987", "AQAAAAEAACcQAAAAEF9wB5qeHCBTDUAxeA+m2PpJNUQkKa+NaJc06ZvPH4Kgbxtcg+JRJ/Dd5f8iCmRahQ==", "8331ddfa-414c-4722-80eb-3cafd16cfcd8" });
        }
    }
}
