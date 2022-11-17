using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddModelsProjectFeedBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    OriginQuestionId = table.Column<Guid>(nullable: false),
                    QuestionTypeId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalQuestions_Configurations_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeAccompanimentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    NextMeetingDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccompanimentPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccompanimentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    Names = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    CampaignName = table.Column<string>(nullable: true),
                    StatusId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    TypeAccompanimentPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccompanimentPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccompanimentPlans_Configurations_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccompanimentPlans_TypeAccompanimentPlans_TypeAccompanimentPlanId",
                        column: x => x.TypeAccompanimentPlanId,
                        principalTable: "TypeAccompanimentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TypeAccompanimentPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireTemplates_TypeAccompanimentPlans_TypeAccompanimentPlanId",
                        column: x => x.TypeAccompanimentPlanId,
                        principalTable: "TypeAccompanimentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseAccompanimentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    TypeAccompanimentPlanId = table.Column<int>(nullable: false),
                    AccompanimentPlanId = table.Column<int>(nullable: false),
                    ScheduledDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    FinalDate = table.Column<DateTime>(nullable: true),
                    UserMadeAccompanimentPlanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseAccompanimentPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseAccompanimentPlans_AccompanimentPlans_AccompanimentPlanId",
                        column: x => x.AccompanimentPlanId,
                        principalTable: "AccompanimentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponseAccompanimentPlans_Users_UserMadeAccompanimentPlanId",
                        column: x => x.UserMadeAccompanimentPlanId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireQuestionTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    OriginQuestionId = table.Column<Guid>(nullable: false),
                    QuestionTypeId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    QuestionnaireTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireQuestionTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireQuestionTemplates_QuestionnaireTemplates_QuestionnaireTemplateId",
                        column: x => x.QuestionnaireTemplateId,
                        principalTable: "QuestionnaireTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseAdditionalQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    ResponseAccompanimentPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseAdditionalQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseAdditionalQuestions_ResponseAccompanimentPlans_ResponseAccompanimentPlanId",
                        column: x => x.ResponseAccompanimentPlanId,
                        principalTable: "ResponseAccompanimentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    QuestionnaireTemplateId = table.Column<int>(nullable: false),
                    QuestionnaireQuestionTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseQuestions_QuestionnaireQuestionTemplates_QuestionnaireQuestionTemplateId",
                        column: x => x.QuestionnaireQuestionTemplateId,
                        principalTable: "QuestionnaireQuestionTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccompanimentPlans_StatusId",
                table: "AccompanimentPlans",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AccompanimentPlans_TypeAccompanimentPlanId",
                table: "AccompanimentPlans",
                column: "TypeAccompanimentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalQuestions_QuestionTypeId",
                table: "AdditionalQuestions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireQuestionTemplates_QuestionnaireTemplateId",
                table: "QuestionnaireQuestionTemplates",
                column: "QuestionnaireTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireTemplates_TypeAccompanimentPlanId",
                table: "QuestionnaireTemplates",
                column: "TypeAccompanimentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseAccompanimentPlans_AccompanimentPlanId",
                table: "ResponseAccompanimentPlans",
                column: "AccompanimentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseAccompanimentPlans_UserMadeAccompanimentPlanId",
                table: "ResponseAccompanimentPlans",
                column: "UserMadeAccompanimentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseAdditionalQuestions_ResponseAccompanimentPlanId",
                table: "ResponseAdditionalQuestions",
                column: "ResponseAccompanimentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseQuestions_QuestionnaireQuestionTemplateId",
                table: "ResponseQuestions",
                column: "QuestionnaireQuestionTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalQuestions");

            migrationBuilder.DropTable(
                name: "ResponseAdditionalQuestions");

            migrationBuilder.DropTable(
                name: "ResponseQuestions");

            migrationBuilder.DropTable(
                name: "ResponseAccompanimentPlans");

            migrationBuilder.DropTable(
                name: "QuestionnaireQuestionTemplates");

            migrationBuilder.DropTable(
                name: "AccompanimentPlans");

            migrationBuilder.DropTable(
                name: "QuestionnaireTemplates");

            migrationBuilder.DropTable(
                name: "TypeAccompanimentPlans");
        }
    }
}
