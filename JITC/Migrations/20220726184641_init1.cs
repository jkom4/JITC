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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f29ecc48-a325-4359-9a29-9443097005fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3d687ea5-4c60-4a7e-af3d-d00de850c48a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f647761a-4f35-4862-a5c0-9f20d11e62c8", "AQAAAAEAACcQAAAAEFK8Dk4vb2meVqcHkC9QxCl5juaFt1NKo/crVKOB7M8qWnqnNIqnD82YpAyOavrnpQ==", "19fe976d-7c57-44aa-aa79-3c2bd146e770" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6e8637b-c046-4c80-b1ad-6ee64924ee27", "AQAAAAEAACcQAAAAEKRyc6adGfANAmHZ8xNAp4fV/YRAiXuVsxY1JRmOoe6Jflt0YvfPDpa4SvvTRMJHRA==", "01d78841-f34c-4958-8a03-3dc8d1e63359" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ae4ad02-0493-42c4-942a-5ad944bfc07a", "AQAAAAEAACcQAAAAEL5kcH2PP9RVbMz+QlkFFGB2j0O/hUFJtt5NVejYaXvDHY9Ulz7fX2cwhzHiuSGVVA==", "3fdac64d-0c5e-4193-a32e-537fb7d8345e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b57446ab-a1f7-4543-89b2-c91609adb24f", "AQAAAAEAACcQAAAAEErxccuLB00g6H044LnKeHGEq/gDYH0pXOwXMZwPrRMMrJLdNCxbn3JpXhrH8JrCzA==", "d3c56cb5-fe08-46fa-815e-5934bf6cbf37" });
        }
    }
}
