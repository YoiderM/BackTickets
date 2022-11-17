using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Añadiendollavesforaneas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "DisciplinaryProcessId",
            //    table: "HistoryChangeprocesses",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "ProcessStatusId",
            //    table: "HistoryChangeprocesses",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_HistoryChangeprocesses_DisciplinaryProcessId",
            //    table: "HistoryChangeprocesses",
            //    column: "DisciplinaryProcessId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HistoryChangeprocesses_ProcessStatusId",
            //    table: "HistoryChangeprocesses",
            //    column: "ProcessStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryChangeprocesses_DisciplinaryProcesses_DisciplinaryProcessId",
                table: "HistoryChangeprocesses",
                column: "DisciplinaryProcessId",
                principalTable: "DisciplinaryProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_HistoryChangeprocesses_ProcessStates_ProcessStatusId",
            //    table: "HistoryChangeprocesses",
            //    column: "ProcessStatusId",
            //    principalTable: "ProcessStates",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryChangeprocesses_DisciplinaryProcesses_DisciplinaryProcessId",
                table: "HistoryChangeprocesses");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryChangeprocesses_ProcessStates_ProcessStatusId",
                table: "HistoryChangeprocesses");

            migrationBuilder.DropIndex(
                name: "IX_HistoryChangeprocesses_DisciplinaryProcessId",
                table: "HistoryChangeprocesses");

            migrationBuilder.DropIndex(
                name: "IX_HistoryChangeprocesses_ProcessStatusId",
                table: "HistoryChangeprocesses");

            migrationBuilder.DropColumn(
                name: "DisciplinaryProcessId",
                table: "HistoryChangeprocesses");

            migrationBuilder.DropColumn(
                name: "ProcessStatusId",
                table: "HistoryChangeprocesses");
        }
    }
}
