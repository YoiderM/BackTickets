using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Añadiendollavesforaneas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryProcesses_ProcessStates_ProcessStatusId",
                table: "DisciplinaryProcesses",
                column: "ProcessStatusId",
                principalTable: "ProcessStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryProcesses_TypesOfFaults_TypeOfFaultId",
                table: "DisciplinaryProcesses",
                column: "TypeOfFaultId",
                principalTable: "TypesOfFaults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryProcesses_ProcessStates_ProcessStatusId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryProcesses_TypesOfFaults_TypeOfFaultId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaryProcesses_ProcessStatusId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaryProcesses_TypeOfFaultId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "ProcessStatusId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "TypeOfFaultId",
                table: "DisciplinaryProcesses");
        }
    }
}
