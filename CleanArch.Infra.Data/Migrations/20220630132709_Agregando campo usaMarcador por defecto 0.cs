using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AgregandocampousaMarcadorpordefecto0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UsesMarker",
                table: "CostCenters",
                nullable: false,
                defaultValue: false);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "UsesMarker",
                table: "CostCenters");
        }
    }
}
