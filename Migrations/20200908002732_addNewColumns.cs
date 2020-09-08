using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRoutesResponses.Migrations
{
    public partial class addNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("89723579-24f8-4314-a4b2-200f2e78c36a"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: new Guid("093f069f-743d-48e3-81c6-c22352d21ca8"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: new Guid("6ad598d5-3c59-487b-b7a6-6ce92dc9fdac"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: new Guid("8ca995b4-2d30-4554-a269-3872ae994c64"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: new Guid("c931445a-c44d-4466-941b-fa6657ddec53"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("c671f0c2-0bea-4a0e-94e2-4f73c2ce6964"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("d98b427f-3c1e-41b4-a47c-1b241be73512"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "User",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Active", "DateCreated", "LastName", "Name", "Phone" },
                values: new object[] { new Guid("03ac173b-2d9a-4e8c-9c34-d5c79c425184"), true, new DateTime(2020, 9, 7, 19, 27, 31, 568, DateTimeKind.Local).AddTicks(5187), "LastName 1", "User 1", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Active", "DateCreated", "LastName", "Name", "Phone" },
                values: new object[] { new Guid("4bbd705c-3e04-412f-94b5-d8f6cd37e823"), true, new DateTime(2020, 9, 7, 19, 27, 31, 571, DateTimeKind.Local).AddTicks(7347), "LastName 2", "User 2", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Active", "DateCreated", "LastName", "Name", "Phone" },
                values: new object[] { new Guid("faa6666b-5600-4a39-9286-39c5ce8c8015"), true, new DateTime(2020, 9, 7, 19, 27, 31, 571, DateTimeKind.Local).AddTicks(7461), "LastName 3", "User 3", null });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "Active", "Description", "Role", "UserId" },
                values: new object[,]
                {
                    { new Guid("a180af88-d341-4c93-8d20-881425303631"), true, null, "Admin", new Guid("03ac173b-2d9a-4e8c-9c34-d5c79c425184") },
                    { new Guid("092e1091-2315-4aad-bb35-f140c7f045df"), true, null, "User", new Guid("03ac173b-2d9a-4e8c-9c34-d5c79c425184") },
                    { new Guid("68d972a2-755d-4c69-8fa8-5963c689245f"), true, null, "Support", new Guid("03ac173b-2d9a-4e8c-9c34-d5c79c425184") },
                    { new Guid("98de4ff8-6ba1-45c1-bafc-a77bddd09ae6"), true, null, "Admin", new Guid("4bbd705c-3e04-412f-94b5-d8f6cd37e823") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("faa6666b-5600-4a39-9286-39c5ce8c8015"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: new Guid("092e1091-2315-4aad-bb35-f140c7f045df"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: new Guid("68d972a2-755d-4c69-8fa8-5963c689245f"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: new Guid("98de4ff8-6ba1-45c1-bafc-a77bddd09ae6"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: new Guid("a180af88-d341-4c93-8d20-881425303631"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("03ac173b-2d9a-4e8c-9c34-d5c79c425184"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("4bbd705c-3e04-412f-94b5-d8f6cd37e823"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "User");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Active", "DateCreated", "LastName", "Name" },
                values: new object[] { new Guid("c671f0c2-0bea-4a0e-94e2-4f73c2ce6964"), true, new DateTime(2020, 9, 7, 19, 25, 5, 806, DateTimeKind.Local).AddTicks(4934), "LastName 1", "User 1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Active", "DateCreated", "LastName", "Name" },
                values: new object[] { new Guid("d98b427f-3c1e-41b4-a47c-1b241be73512"), true, new DateTime(2020, 9, 7, 19, 25, 5, 808, DateTimeKind.Local).AddTicks(7213), "LastName 2", "User 2" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Active", "DateCreated", "LastName", "Name" },
                values: new object[] { new Guid("89723579-24f8-4314-a4b2-200f2e78c36a"), true, new DateTime(2020, 9, 7, 19, 25, 5, 808, DateTimeKind.Local).AddTicks(7288), "LastName 3", "User 3" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "Active", "Role", "UserId" },
                values: new object[,]
                {
                    { new Guid("c931445a-c44d-4466-941b-fa6657ddec53"), true, "Admin", new Guid("c671f0c2-0bea-4a0e-94e2-4f73c2ce6964") },
                    { new Guid("6ad598d5-3c59-487b-b7a6-6ce92dc9fdac"), true, "User", new Guid("c671f0c2-0bea-4a0e-94e2-4f73c2ce6964") },
                    { new Guid("093f069f-743d-48e3-81c6-c22352d21ca8"), true, "Support", new Guid("c671f0c2-0bea-4a0e-94e2-4f73c2ce6964") },
                    { new Guid("8ca995b4-2d30-4554-a269-3872ae994c64"), true, "Admin", new Guid("d98b427f-3c1e-41b4-a47c-1b241be73512") }
                });
        }
    }
}
