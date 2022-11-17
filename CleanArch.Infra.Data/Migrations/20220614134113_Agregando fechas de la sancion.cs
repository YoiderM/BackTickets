using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Agregandofechasdelasancion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfHealing",
                table: "DisciplinaryProcesses");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEndOfHealing",
                table: "DisciplinaryProcesses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStartOfHealing",
                table: "DisciplinaryProcesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEndOfHealing",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "DateStartOfHealing",
                table: "DisciplinaryProcesses");

            migrationBuilder.AddColumn<string>(
                name: "DateOfHealing",
                table: "DisciplinaryProcesses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
