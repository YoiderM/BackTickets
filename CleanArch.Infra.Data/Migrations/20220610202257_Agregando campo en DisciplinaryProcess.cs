using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AgregandocampoenDisciplinaryProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateOfHealing",
                table: "DisciplinaryProcesses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfHealing",
                table: "DisciplinaryProcesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionOfTheHealing",
                table: "DisciplinaryProcesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionResponseLegal",
                table: "DisciplinaryProcesses",
                nullable: true);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfHealing",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "DayOfHealing",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "DescriptionOfTheHealing",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "DescriptionResponseLegal",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "userProcessApplicantId",
                table: "DisciplinaryProcesses");
        }
    }
}
