using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class areeliminatethetableNoveltyHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoveltyHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoveltyHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MadeByUserId = table.Column<int>(type: "int", nullable: false),
                    NoveltyEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoveltyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoveltyHistory_MekanoUsers_MadeByUserId",
                        column: x => x.MadeByUserId,
                        principalTable: "MekanoUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoveltyHistory_NoveltyEntry_NoveltyEntryId",
                        column: x => x.NoveltyEntryId,
                        principalTable: "NoveltyEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoveltyHistory_MadeByUserId",
                table: "NoveltyHistory",
                column: "MadeByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoveltyHistory_NoveltyEntryId",
                table: "NoveltyHistory",
                column: "NoveltyEntryId");
        }
    }
}
