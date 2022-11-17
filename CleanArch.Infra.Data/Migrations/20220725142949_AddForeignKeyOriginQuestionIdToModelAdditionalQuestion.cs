using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddForeignKeyOriginQuestionIdToModelAdditionalQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AdditionalQuestions_OriginQuestionId",
                table: "AdditionalQuestions",
                column: "OriginQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalQuestions_Configurations_OriginQuestionId",
                table: "AdditionalQuestions",
                column: "OriginQuestionId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalQuestions_Configurations_OriginQuestionId",
                table: "AdditionalQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalQuestions_OriginQuestionId",
                table: "AdditionalQuestions");
        }
    }
}
