using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class OvertimeTemptData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalHours",
                table: "OvertimeTemps",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "SundayNumbre2",
                table: "OvertimeTemps",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "SundayNumber1",
                table: "OvertimeTemps",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "OvertimeTypeName",
                table: "OvertimeTemps",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndHour",
                table: "OvertimeTemps",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CompensatoryApplies",
                table: "OvertimeTemps",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "LoginTime",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentPercent",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salary",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndHour",
                table: "OvertimeDetails",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "LoginTime",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentPercent",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "OvertimeDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobName",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "LoginTime",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "PaymentPercent",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "JobName",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "LoginTime",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "PaymentPercent",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "OvertimeDetails");

            migrationBuilder.AlterColumn<int>(
                name: "TotalHours",
                table: "OvertimeTemps",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SundayNumbre2",
                table: "OvertimeTemps",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SundayNumber1",
                table: "OvertimeTemps",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OvertimeTypeName",
                table: "OvertimeTemps",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndHour",
                table: "OvertimeTemps",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CompensatoryApplies",
                table: "OvertimeTemps",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndHour",
                table: "OvertimeDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);
        }
    }
}
