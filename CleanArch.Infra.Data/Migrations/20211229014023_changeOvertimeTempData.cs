using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class changeOvertimeTempData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LoginTime",
                table: "OvertimeTemps",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialHour",
                table: "OvertimeTemps",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndHour",
                table: "OvertimeTemps",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoginTimeText",
                table: "OvertimeTemps",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginTimeText",
                table: "OvertimeTemps");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "LoginTime",
                table: "OvertimeTemps",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "InitialHour",
                table: "OvertimeTemps",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndHour",
                table: "OvertimeTemps",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
