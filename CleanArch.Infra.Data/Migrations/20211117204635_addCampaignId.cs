using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class addCampaignId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CampaingName",
                table: "OvertimeTemps",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "OvertimeDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CampaingName",
                table: "OvertimeDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
