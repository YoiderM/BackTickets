using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class addCostCenterToMekanoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "MekanoUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostCenterId",
                table: "MekanoUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MekanoUsers_CostCenterId",
                table: "MekanoUsers",
                column: "CostCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MekanoUsers_CostCenters_CostCenterId",
                table: "MekanoUsers",
                column: "CostCenterId",
                principalTable: "CostCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MekanoUsers_CostCenters_CostCenterId",
                table: "MekanoUsers");

            migrationBuilder.DropIndex(
                name: "IX_MekanoUsers_CostCenterId",
                table: "MekanoUsers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "MekanoUsers");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "MekanoUsers");
        }
    }
}
