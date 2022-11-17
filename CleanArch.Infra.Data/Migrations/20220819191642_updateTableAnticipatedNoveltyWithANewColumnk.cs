using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class updateTableAnticipatedNoveltyWithANewColumnk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoveltyInit",
                table: "AnticipatedNovelty",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoveltyInit",
                table: "AnticipatedNovelty");
        }
    }
}
