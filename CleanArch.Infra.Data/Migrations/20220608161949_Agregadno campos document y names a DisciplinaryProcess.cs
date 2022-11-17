using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AgregadnocamposdocumentynamesaDisciplinaryProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "DisciplinaryProcesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "DisciplinaryProcesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "DisciplinaryProcesses");
        }
    }
}
