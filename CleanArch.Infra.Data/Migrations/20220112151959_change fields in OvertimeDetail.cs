using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class changefieldsinOvertimeDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaingName",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "CampaingName",
                table: "OvertimeDetails");

            migrationBuilder.AddColumn<int>(
                name: "CostCenterId",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostCenterName",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostCenterId",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostCenterName",
                table: "OvertimeDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeDetails_CostCenterId",
                table: "OvertimeDetails",
                column: "CostCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_OvertimeDetails_CostCenters_CostCenterId",
                table: "OvertimeDetails",
                column: "CostCenterId",
                principalTable: "CostCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OvertimeDetails_CostCenters_CostCenterId",
                table: "OvertimeDetails");

            migrationBuilder.DropIndex(
                name: "IX_OvertimeDetails_CostCenterId",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "CostCenterName",
                table: "OvertimeTemps");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "CostCenterName",
                table: "OvertimeDetails");

            migrationBuilder.AddColumn<string>(
                name: "CampaingName",
                table: "OvertimeTemps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "OvertimeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CampaingName",
                table: "OvertimeDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
