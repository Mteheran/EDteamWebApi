using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRoutesResponses.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
