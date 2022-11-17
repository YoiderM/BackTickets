using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class RemoviendocamposdelmodeloOvertimeDetailDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostCenterName",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "OvertimeTypeName",
                table: "OvertimeDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CostCenterName",
                table: "OvertimeDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OvertimeTypeName",
                table: "OvertimeDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
