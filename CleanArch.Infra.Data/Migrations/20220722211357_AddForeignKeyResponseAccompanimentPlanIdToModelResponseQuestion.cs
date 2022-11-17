using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddForeignKeyResponseAccompanimentPlanIdToModelResponseQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseAccompanimentPlanId",
                table: "ResponseQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResponseQuestions_ResponseAccompanimentPlanId",
                table: "ResponseQuestions",
                column: "ResponseAccompanimentPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseQuestions_ResponseAccompanimentPlans_ResponseAccompanimentPlanId",
                table: "ResponseQuestions",
                column: "ResponseAccompanimentPlanId",
                principalTable: "ResponseAccompanimentPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseQuestions_ResponseAccompanimentPlans_ResponseAccompanimentPlanId",
                table: "ResponseQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ResponseQuestions_ResponseAccompanimentPlanId",
                table: "ResponseQuestions");

            migrationBuilder.DropColumn(
                name: "ResponseAccompanimentPlanId",
                table: "ResponseQuestions");
        }
    }
}
