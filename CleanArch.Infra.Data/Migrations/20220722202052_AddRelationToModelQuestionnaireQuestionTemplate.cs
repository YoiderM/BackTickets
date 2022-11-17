using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddRelationToModelQuestionnaireQuestionTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ResponseAccompanimentPlans_TypeAccompanimentPlanId",
                table: "ResponseAccompanimentPlans",
                column: "TypeAccompanimentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireQuestionTemplates_OriginQuestionId",
                table: "QuestionnaireQuestionTemplates",
                column: "OriginQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireQuestionTemplates_QuestionTypeId",
                table: "QuestionnaireQuestionTemplates",
                column: "QuestionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireQuestionTemplates_Configurations_OriginQuestionId",
                table: "QuestionnaireQuestionTemplates",
                column: "OriginQuestionId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireQuestionTemplates_Configurations_QuestionTypeId",
                table: "QuestionnaireQuestionTemplates",
                column: "QuestionTypeId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseAccompanimentPlans_TypeAccompanimentPlans_TypeAccompanimentPlanId",
                table: "ResponseAccompanimentPlans",
                column: "TypeAccompanimentPlanId",
                principalTable: "TypeAccompanimentPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireQuestionTemplates_Configurations_OriginQuestionId",
                table: "QuestionnaireQuestionTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireQuestionTemplates_Configurations_QuestionTypeId",
                table: "QuestionnaireQuestionTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseAccompanimentPlans_TypeAccompanimentPlans_TypeAccompanimentPlanId",
                table: "ResponseAccompanimentPlans");

            migrationBuilder.DropIndex(
                name: "IX_ResponseAccompanimentPlans_TypeAccompanimentPlanId",
                table: "ResponseAccompanimentPlans");

            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireQuestionTemplates_OriginQuestionId",
                table: "QuestionnaireQuestionTemplates");

            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireQuestionTemplates_QuestionTypeId",
                table: "QuestionnaireQuestionTemplates");
        }
    }
}
