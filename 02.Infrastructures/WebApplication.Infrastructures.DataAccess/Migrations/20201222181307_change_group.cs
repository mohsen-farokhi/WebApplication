using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Infrastructures.DataAccess.Migrations
{
    public partial class change_group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDateTime",
                table: "Groups",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystem",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Groups",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDateTime", "UpdateDateTime" },
                values: new object[] { new DateTime(2020, 12, 22, 21, 43, 6, 420, DateTimeKind.Local).AddTicks(2083), new DateTime(2020, 12, 22, 21, 43, 6, 434, DateTimeKind.Local).AddTicks(254) });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertDateTime", "UpdateDateTime" },
                values: new object[] { new DateTime(2020, 12, 22, 21, 43, 6, 434, DateTimeKind.Local).AddTicks(8169), new DateTime(2020, 12, 22, 21, 43, 6, 434, DateTimeKind.Local).AddTicks(8190) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDateTime",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsSystem",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDateTime", "UpdateDateTime" },
                values: new object[] { new DateTime(2020, 11, 3, 9, 2, 56, 215, DateTimeKind.Local).AddTicks(2583), new DateTime(2020, 11, 3, 9, 2, 56, 219, DateTimeKind.Local).AddTicks(458) });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertDateTime", "UpdateDateTime" },
                values: new object[] { new DateTime(2020, 11, 3, 9, 2, 56, 219, DateTimeKind.Local).AddTicks(9973), new DateTime(2020, 11, 3, 9, 2, 56, 220, DateTimeKind.Local).AddTicks(13) });
        }
    }
}
