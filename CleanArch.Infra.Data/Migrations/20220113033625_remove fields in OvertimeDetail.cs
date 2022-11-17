using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class removefieldsinOvertimeDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndHourText",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "InitialHourText",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "OvertimeDayText",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "CurriculumId",
                table: "OvertimeDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndHourText",
                table: "OvertimeTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitialHourText",
                table: "OvertimeTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OvertimeDayText",
                table: "OvertimeTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurriculumId",
                table: "OvertimeDetails",
                type: "int",
                nullable: true);
        }
    }
}
