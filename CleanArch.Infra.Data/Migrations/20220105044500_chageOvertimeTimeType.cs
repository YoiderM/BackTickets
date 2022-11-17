using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class chageOvertimeTimeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OvertimeTypeId",
                table: "OvertimeTemps");

            migrationBuilder.AddColumn<Guid>(
                name: "OvertimeType",
                table: "OvertimeTemps",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OvertimeType",
                table: "OvertimeTemps");

            migrationBuilder.AddColumn<int>(
                name: "OvertimeTypeId",
                table: "OvertimeTemps",
                type: "int",
                nullable: true);
        }
    }
}
