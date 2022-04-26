using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a809877-6278-492b-b734-810229bfcca3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1760466-5d81-421e-9374-9a72d977283e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91b65adf-7475-4260-b5d0-45d1cc6a6fee", "9cc2b5d4-4de3-4423-90bf-4c8bba5919c2", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8a0d1fd-a16b-4183-aa2d-cd2bd2bce9c1", "cb05fc61-8282-4a02-b9ec-d465dbb346b8", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "OfficePhone", "OrganizationId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SpecializationId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7a969f9-8e40-4219-8aec-dd5ff9d08a89", 0, "d1f4090b-d48e-4e7f-863c-c6b792c66c1c", "stefanstrauberg@gmail.com", true, "Ruslan", false, "Stsefanovich", false, null, "Sergeevich", "STEFANSTRAUBERG@GMAIL.COM", "ADMIN", null, null, "AQAAAAEAACcQAAAAEInHyBa0wH/Nn94Rvq05ZzA479lsE34I34+dBvQvRKVnZZklqibwlX4bATjZdtuFqg==", "+375297772226665", true, "e94cffa0-0839-4dfc-8365-3d5e39bae927", null, false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91b65adf-7475-4260-b5d0-45d1cc6a6fee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8a0d1fd-a16b-4183-aa2d-cd2bd2bce9c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7a969f9-8e40-4219-8aec-dd5ff9d08a89");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a809877-6278-492b-b734-810229bfcca3", "e910433d-f398-4875-a342-7d5a52f72067", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1760466-5d81-421e-9374-9a72d977283e", "931ebd6e-26e1-44dd-9cfd-f4eef80649f0", "Visitor", "VISITOR" });
        }
    }
}
