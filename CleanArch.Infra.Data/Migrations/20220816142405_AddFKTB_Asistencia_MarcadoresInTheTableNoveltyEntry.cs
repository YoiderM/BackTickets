using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddFKTB_Asistencia_MarcadoresInTheTableNoveltyEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AsistenciaMarcadoresId",
                table: "NoveltyEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NoveltyEntry_AsistenciaMarcadoresId",
                table: "NoveltyEntry",
                column: "AsistenciaMarcadoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoveltyEntry_TB_ASISTENCIA_MARCADORES_AsistenciaMarcadoresId",
                table: "NoveltyEntry",
                column: "AsistenciaMarcadoresId",
                principalTable: "TB_ASISTENCIA_MARCADORES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoveltyEntry_TB_ASISTENCIA_MARCADORES_AsistenciaMarcadoresId",
                table: "NoveltyEntry");

            migrationBuilder.DropIndex(
                name: "IX_NoveltyEntry_AsistenciaMarcadoresId",
                table: "NoveltyEntry");

            migrationBuilder.DropColumn(
                name: "AsistenciaMarcadoresId",
                table: "NoveltyEntry");
        }
    }
}
