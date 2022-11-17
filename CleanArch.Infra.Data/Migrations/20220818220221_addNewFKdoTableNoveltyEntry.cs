using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class addNewFKdoTableNoveltyEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MekanoUserId",
                table: "NoveltyEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NoveltyEntry_MekanoUserId",
                table: "NoveltyEntry",
                column: "MekanoUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoveltyEntry_MekanoUsers_MekanoUserId",
                table: "NoveltyEntry",
                column: "MekanoUserId",
                principalTable: "MekanoUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoveltyEntry_MekanoUsers_MekanoUserId",
                table: "NoveltyEntry");

            migrationBuilder.DropIndex(
                name: "IX_NoveltyEntry_MekanoUserId",
                table: "NoveltyEntry");

            migrationBuilder.DropColumn(
                name: "MekanoUserId",
                table: "NoveltyEntry");
        }
    }
}
