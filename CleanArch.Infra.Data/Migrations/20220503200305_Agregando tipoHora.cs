using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AgregandotipoHora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OvertimeDetails_CostCenters_CostCenterId",
                table: "OvertimeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OvertimeDetails_OvertimePeriods_OvertimePeriodId",
                table: "OvertimeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OvertimeDetails_OvertimeTypes_OvertimeTypeId",
                table: "OvertimeDetails");

            migrationBuilder.DropIndex(
                name: "IX_OvertimeDetails_CostCenterId",
                table: "OvertimeDetails");

            migrationBuilder.DropIndex(
                name: "IX_OvertimeDetails_OvertimePeriodId",
                table: "OvertimeDetails");

            migrationBuilder.DropIndex(
                name: "IX_OvertimeDetails_OvertimeTypeId",
                table: "OvertimeDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "OvertimeDetailId",
                table: "OvertimeTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeHour",
                table: "OvertimeTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OvertimeDetailId",
                table: "OvertimePeriods",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Names",
                table: "OvertimeDetails",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OvertimeDetailId",
                table: "CostCenters",
                nullable: true);

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
     
            migrationBuilder.DropIndex(
                name: "IX_OvertimeTypes_OvertimeDetailId",
                table: "OvertimeTypes");

            migrationBuilder.DropIndex(
                name: "IX_OvertimePeriods_OvertimeDetailId",
                table: "OvertimePeriods");

            migrationBuilder.DropIndex(
                name: "IX_CostCenters_OvertimeDetailId",
                table: "CostCenters");

            migrationBuilder.DropColumn(
                name: "OvertimeDetailId",
                table: "OvertimeTypes");

            migrationBuilder.DropColumn(
                name: "TypeHour",
                table: "OvertimeTypes");

            migrationBuilder.DropColumn(
                name: "OvertimeDetailId",
                table: "OvertimePeriods");

            migrationBuilder.DropColumn(
                name: "OvertimeDetailId",
                table: "CostCenters");

            migrationBuilder.AlterColumn<string>(
                name: "Names",
                table: "OvertimeDetails",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

           

            migrationBuilder.AddForeignKey(
                name: "FK_OvertimeDetails_CostCenters_CostCenterId",
                table: "OvertimeDetails",
                column: "CostCenterId",
                principalTable: "CostCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OvertimeDetails_OvertimePeriods_OvertimePeriodId",
                table: "OvertimeDetails",
                column: "OvertimePeriodId",
                principalTable: "OvertimePeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OvertimeDetails_OvertimeTypes_OvertimeTypeId",
                table: "OvertimeDetails",
                column: "OvertimeTypeId",
                principalTable: "OvertimeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
