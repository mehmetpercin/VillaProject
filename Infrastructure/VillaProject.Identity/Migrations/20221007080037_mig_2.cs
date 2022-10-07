using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillaProject.Identity.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8410b5f1-8795-4f88-8c47-6736a193dd16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b795de63-0754-4522-86c5-e494a6496484");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "UserRefreshTokens",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05ef4296-1e7d-47db-8e3b-ba2b28bdffda", "ea83c072-435c-4b8a-846c-354c0db7dd87", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c93afe0-522c-4a7e-97e0-1bcc839033ce", "a537ec2a-66f6-4b7b-94a3-013cce8d181e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05ef4296-1e7d-47db-8e3b-ba2b28bdffda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c93afe0-522c-4a7e-97e0-1bcc839033ce");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "UserRefreshTokens",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8410b5f1-8795-4f88-8c47-6736a193dd16", "1d9589f4-ae74-445d-8fe8-09a65d2b51cd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b795de63-0754-4522-86c5-e494a6496484", "149ed5e2-f4ba-4832-beef-a2db387c80d4", "Admin", "ADMIN" });
        }
    }
}
