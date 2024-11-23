using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d2f5a18-14ce-4415-aa1f-505c01396371", "", "", "AQAAAAEAACcQAAAAEHPbk2fAEEL1hpcg6ldFGuxgy6vuI7/0kwTn/LD2RxfI56MBbayU7hY1+iAWElKAAQ==", "02331e60-cedf-4793-ab31-03d601e5af13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5efc6be-c1b5-4f80-b4a7-67a8444d23f5", "", "", "AQAAAAEAACcQAAAAEKZkNJ8dYJzSRdRj7a52QhBBJE6y8fsYbVyEBF44KUQDgTk0oOlQa2FIXOqJbhtyUg==", "e5052b69-2f19-4c41-9a80-4631a20dd7a0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
        }
    }
}
