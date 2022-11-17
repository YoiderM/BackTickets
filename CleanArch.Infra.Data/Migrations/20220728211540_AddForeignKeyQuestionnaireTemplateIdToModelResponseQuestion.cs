using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddForeignKeyQuestionnaireTemplateIdToModelResponseQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ResponseQuestions_QuestionnaireTemplateId",
                table: "ResponseQuestions",
                column: "QuestionnaireTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseQuestions_QuestionnaireTemplates_QuestionnaireTemplateId",
                table: "ResponseQuestions",
                column: "QuestionnaireTemplateId",
                principalTable: "QuestionnaireTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseQuestions_QuestionnaireTemplates_QuestionnaireTemplateId",
                table: "ResponseQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ResponseQuestions_QuestionnaireTemplateId",
                table: "ResponseQuestions");
        }
    }
}
