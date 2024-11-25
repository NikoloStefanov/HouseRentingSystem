using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class AdminPasswordSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec0b0488-59be-45d3-9e29-ade4e445e0df", "AQAAAAEAACcQAAAAEOfPN9RagufLbp1a9M8+EWOTvQl3pEIUP8QY7soqmLuvLMjU/cVsNUavOmrpB6ZAMQ==", "e9e637ec-f61f-4578-a799-94724a995df5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07944459-b665-475d-86ee-96fa746d1c1b", "AQAAAAEAACcQAAAAEGpfGV4CM6Hpu6rJHrACu7kMTdoq7CAOv+OFpBg2+I1Qk6Kj3HJBoo+2s8nGjNwKOw==", "454a2a18-fa76-4e3a-b577-b184819c45e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09430ace-4188-428a-a58e-2099e09a0ec9", "AQAAAAEAACcQAAAAEJeVMNvpmRSp0QrirdDeRPF/Ci2WZ27RuMgTKXEFNdJ2ZMqefC7j34upDlNMzSTOtw==", "62a11c73-2933-4fd5-afda-73f8802b5f2a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1325241c-c4b9-4ec7-8adb-db68c9e04fa2", null, "0ebdcdcb-3c35-4741-8fcd-9c10e42e2a66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "567af900-e105-49a4-893c-45fd635bafd3", "AQAAAAEAACcQAAAAEM6KtHhLDhAV98AIStbRX/wt4gxeaOjlFYNBx9RMew91RziWg1852dnCNREXvTIYOw==", "7fa5077b-3a73-47c6-b567-90c02b361a28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a010a34-bd61-428c-b90a-333484eba845", "AQAAAAEAACcQAAAAEIR/0r2gmdIEJ4a+qXUS/uZ3vBtqdVz8hUJhTbnvyg+HxVIn2pYP0GNkeydIDvZ+Aw==", "db798acc-6c1a-4dd7-95e5-7e3e03f14683" });
        }
    }
}
