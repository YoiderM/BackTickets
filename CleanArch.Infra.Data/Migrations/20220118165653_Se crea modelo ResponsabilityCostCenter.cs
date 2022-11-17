using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class SecreamodeloResponsabilityCostCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponsabilitiesCostCenter",
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
                    UserId = table.Column<Guid>(nullable: false),
                    CostCenterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsabilitiesCostCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsabilitiesCostCenter_CostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ResponsabilitiesCostCenter_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsabilitiesCostCenter_CostCenterId",
                table: "ResponsabilitiesCostCenter",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsabilitiesCostCenter_UserId",
                table: "ResponsabilitiesCostCenter",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsabilitiesCostCenter");
        }
    }
}
