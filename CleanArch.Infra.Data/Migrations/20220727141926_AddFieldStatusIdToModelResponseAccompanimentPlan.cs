using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddFieldStatusIdToModelResponseAccompanimentPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "ResponseAccompanimentPlans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ResponseAccompanimentPlans_StatusId",
                table: "ResponseAccompanimentPlans",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseAccompanimentPlans_Configurations_StatusId",
                table: "ResponseAccompanimentPlans",
                column: "StatusId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseAccompanimentPlans_Configurations_StatusId",
                table: "ResponseAccompanimentPlans");

            migrationBuilder.DropIndex(
                name: "IX_ResponseAccompanimentPlans_StatusId",
                table: "ResponseAccompanimentPlans");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ResponseAccompanimentPlans");
        }
    }
}
