using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddFieldConclusionsAndCommitmentsToModelResponseAccompanimentPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConclusionsAndCommitments",
                table: "ResponseAccompanimentPlans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConclusionsAndCommitments",
                table: "ResponseAccompanimentPlans");
        }
    }
}
