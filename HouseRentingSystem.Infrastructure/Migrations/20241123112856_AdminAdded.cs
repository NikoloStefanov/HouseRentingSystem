using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "567af900-e105-49a4-893c-45fd635bafd3", "Martin", "Vasilev", "AQAAAAEAACcQAAAAEM6KtHhLDhAV98AIStbRX/wt4gxeaOjlFYNBx9RMew91RziWg1852dnCNREXvTIYOw==", "7fa5077b-3a73-47c6-b567-90c02b361a28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a010a34-bd61-428c-b90a-333484eba845", "Ivailo", "Petkov", "AQAAAAEAACcQAAAAEIR/0r2gmdIEJ4a+qXUS/uZ3vBtqdVz8hUJhTbnvyg+HxVIn2pYP0GNkeydIDvZ+Aw==", "db798acc-6c1a-4dd7-95e5-7e3e03f14683" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591", 0, "1325241c-c4b9-4ec7-8adb-db68c9e04fa2", "admin@mail.com", false, "Admin", "Stefanov", false, null, "admin@mail.com", "admin@mail.com", null, null, false, "0ebdcdcb-3c35-4741-8fcd-9c10e42e2a66", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 5, "+359123456789", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591");

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
    }
}
