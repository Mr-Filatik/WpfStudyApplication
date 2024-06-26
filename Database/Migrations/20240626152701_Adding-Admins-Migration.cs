using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfStudyApplication.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddingAdminsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDay",
                value: new DateTime(2024, 6, 26, 15, 27, 1, 397, DateTimeKind.Utc).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(2024, 6, 26, 15, 27, 1, 397, DateTimeKind.Utc).AddTicks(2513));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDay",
                value: new DateTime(2024, 6, 26, 15, 19, 57, 494, DateTimeKind.Utc).AddTicks(59));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(2024, 6, 26, 15, 19, 57, 494, DateTimeKind.Utc).AddTicks(91));
        }
    }
}
