using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class fieldsareaddedtothedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "OvertimeTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsHoliday",
                table: "OvertimeTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaximumHours",
                table: "OvertimeTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "OvertimeTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "OvertimeTypes");

            migrationBuilder.DropColumn(
                name: "IsHoliday",
                table: "OvertimeTypes");

            migrationBuilder.DropColumn(
                name: "MaximumHours",
                table: "OvertimeTypes");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "OvertimeTypes");
        }
    }
}
