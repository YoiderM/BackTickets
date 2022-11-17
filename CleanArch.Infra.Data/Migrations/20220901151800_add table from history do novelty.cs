using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class addtablefromhistorydonovelty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoveltyHistory",
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
                    date = table.Column<DateTime>(nullable: false),
                    InitialState = table.Column<string>(nullable: true),
                    EndState = table.Column<string>(nullable: true),
                    Observation = table.Column<string>(nullable: true),
                    MadeByUserId = table.Column<int>(nullable: false),
                    NoveltyEntryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoveltyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoveltyHistory_MekanoUsers_MadeByUserId",
                        column: x => x.MadeByUserId,
                        principalTable: "MekanoUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NoveltyHistory_NoveltyEntry_NoveltyEntryId",
                        column: x => x.NoveltyEntryId,
                        principalTable: "NoveltyEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoveltyHistory");
        }
    }
}
