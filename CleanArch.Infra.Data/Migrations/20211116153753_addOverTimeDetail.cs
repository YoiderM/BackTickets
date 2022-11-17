using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class addOverTimeDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description1",
                table: "OvertimeTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "OvertimeTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminObservation",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthObservation",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CompensatoryApplies",
                table: "OvertimeTemps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndHour",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndHourText",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "InitialHour",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitialHourText",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OvertimeDay",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OvertimeDayText",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OvertimeTypeName",
                table: "OvertimeTemps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SundayNumber1",
                table: "OvertimeTemps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SundayNumbre2",
                table: "OvertimeTemps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "OvertimeTemps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "User",
                table: "OvertimeTemps",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "UserStatus",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminObservation",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthObservation",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CompensatoryApplies",
                table: "OvertimeDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndHour",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "InitialHour",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OvertimeDay",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OvertimeTypeName",
                table: "OvertimeDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SundayNumber1",
                table: "OvertimeDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SundayNumbre2",
                table: "OvertimeDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "OvertimeDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "User",
                table: "OvertimeDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "UserStatus",
                table: "OvertimeDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description1",
                table: "OvertimeTypes");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "OvertimeTypes");

            migrationBuilder.DropColumn(
                name: "AdminObservation",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "AuthObservation",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "CompensatoryApplies",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "EndHour",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "EndHourText",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "InitialHour",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "InitialHourText",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "OvertimeDay",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "OvertimeDayText",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "OvertimeTypeName",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "SundayNumber1",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "SundayNumbre2",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "User",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "AdminObservation",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "AuthObservation",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "CompensatoryApplies",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "EndHour",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "InitialHour",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "OvertimeDay",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "OvertimeTypeName",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "SundayNumber1",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "SundayNumbre2",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "User",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "OvertimeDetails");
        }
    }
}
