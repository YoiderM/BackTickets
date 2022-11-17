using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class LimitandocamposOvertimeDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            

            

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "OvertimeDetails",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeDetails_CostCenterId",
                table: "OvertimeDetails",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeDetails_OvertimePeriodId",
                table: "OvertimeDetails",
                column: "OvertimePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeDetails_OvertimeTypeId",
                table: "OvertimeDetails",
                column: "OvertimeTypeId");        

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
      
            migrationBuilder.AddColumn<Guid>(
                name: "OvertimeDetailId",
                table: "OvertimeTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OvertimeDetailId",
                table: "OvertimePeriods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "OvertimeDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OvertimeDetailId",
                table: "CostCenters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeTypes_OvertimeDetailId",
                table: "OvertimeTypes",
                column: "OvertimeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimePeriods_OvertimeDetailId",
                table: "OvertimePeriods",
                column: "OvertimeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenters_OvertimeDetailId",
                table: "CostCenters",
                column: "OvertimeDetailId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CostCenters_OvertimeDetails_OvertimeDetailId",
            //    table: "CostCenters",
            //    column: "OvertimeDetailId",
            //    principalTable: "OvertimeDetails",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OvertimePeriods_OvertimeDetails_OvertimeDetailId",
            //    table: "OvertimePeriods",
            //    column: "OvertimeDetailId",
            //    principalTable: "OvertimeDetails",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OvertimeTypes_OvertimeDetails_OvertimeDetailId",
            //    table: "OvertimeTypes",
            //    column: "OvertimeDetailId",
            //    principalTable: "OvertimeDetails",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
