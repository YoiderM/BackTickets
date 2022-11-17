using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class addModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CanChanged = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OvertimePeriods",
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
                    StartAllowedDate = table.Column<DateTime>(nullable: true),
                    EndAllowedDate = table.Column<DateTime>(nullable: true),
                    StartPeriodDate = table.Column<DateTime>(nullable: true),
                    EndPeriodDate = table.Column<DateTime>(nullable: true),
                    WeekNumber = table.Column<int>(nullable: true),
                    fortnight = table.Column<int>(nullable: true),
                    IsOpen = table.Column<bool>(nullable: true),
                    IsPaid = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimePeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OvertimeTemps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    UserDocument = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimeTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OvertimeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    payPercent = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    GuidId = table.Column<Guid>(nullable: true),
                    GuidId2 = table.Column<Guid>(nullable: true),
                    GuidId3 = table.Column<Guid>(nullable: true),
                    BoolId1 = table.Column<bool>(nullable: true),
                    BoolId2 = table.Column<bool>(nullable: true),
                    BoolId3 = table.Column<bool>(nullable: true),
                    IntId = table.Column<int>(nullable: true),
                    IntId1 = table.Column<int>(nullable: true),
                    IntId2 = table.Column<int>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OvertimeDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    OvertimeTypeId = table.Column<Guid>(nullable: false),
                    OvertimePeriodId = table.Column<int>(nullable: true),
                    AprovedBy = table.Column<Guid>(nullable: true),
                    Aproved = table.Column<bool>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OvertimeDetails_OvertimePeriods_OvertimePeriodId",
                        column: x => x.OvertimePeriodId,
                        principalTable: "OvertimePeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OvertimeDetails_OvertimeTypes_OvertimeTypeId",
                        column: x => x.OvertimeTypeId,
                        principalTable: "OvertimeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
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
                    Day = table.Column<DateTime>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_Configurations_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollAuthorizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    CampaignId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollAuthorizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollAuthorizes_Configurations_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_CategoryId",
                table: "Configurations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_TypeId",
                table: "Holidays",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeDetails_OvertimePeriodId",
                table: "OvertimeDetails",
                column: "OvertimePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeDetails_OvertimeTypeId",
                table: "OvertimeDetails",
                column: "OvertimeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollAuthorizes_TypeId",
                table: "PayrollAuthorizes",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "OvertimeDetails");

            migrationBuilder.DropTable(
                name: "OvertimeTemps");

            migrationBuilder.DropTable(
                name: "PayrollAuthorizes");

            migrationBuilder.DropTable(
                name: "OvertimePeriods");

            migrationBuilder.DropTable(
                name: "OvertimeTypes");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
