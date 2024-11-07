using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Agents",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46a93ee0-6f99-43bf-a869-cd06dfe804be", "AQAAAAEAACcQAAAAEN86D+ZweWk8gXLL6MJp5ceFMOOEKifemR6Lg7FkJK2FFvsliZmRA9E8s2ca8Epnaw==", "f7d93743-4a27-479d-a621-559fd3feb45f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd1041b3-3c3b-4110-ab0c-e6b2878d230d", "AQAAAAEAACcQAAAAEGq75fzgpw52MVjXjc5urQKowySfKiQHbLjMTTaJ7CYi6h5eksG5MMxsXSGX4Esk7Q==", "9c7731a7-4944-43a5-8cef-101fdeb53b88" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Agents",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "303bed9b-afb7-4cd6-bddb-a3a865bb9eb0", "AQAAAAEAACcQAAAAEPmPBUx1RTXb2HTtAvFV3F0mi5z8l9SAzAvYcSnuJR3MkJtIakrVrCSizQjGZpIfcg==", "46bd061a-658e-410e-bf16-7d458ceae99a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "632be35c-b623-4f89-9b8a-f141fdf0581d", "AQAAAAEAACcQAAAAEJ+U0LU7Ht+J9VVzplxhtoAOk+iHg0GCPLppiDDhU61y1cVCZJLf67+++M1LPpGviQ==", "0695453d-5b36-4327-adb3-d3b0da9367a0" });
        }
    }
}
