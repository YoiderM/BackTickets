using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Cambiandollavesforaneasenmodelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryProcesses_ProcessStates_ProcessStatusId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaryProcesses_ProcessStatusId",
                table: "DisciplinaryProcesses");

            migrationBuilder.AddColumn<Guid>(
                name: "ProcessStatusId",
                table: "HistoryChangeprocesses",
                nullable: true
                //defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
                );

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChangeprocesses_ProcessStatusId",
                table: "HistoryChangeprocesses",
                column: "ProcessStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryChangeprocesses_ProcessStates_ProcessStatusId",
                table: "HistoryChangeprocesses",
                column: "ProcessStatusId",
                principalTable: "ProcessStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryChangeprocesses_ProcessStates_ProcessStatusId",
                table: "HistoryChangeprocesses");

            migrationBuilder.DropIndex(
                name: "IX_HistoryChangeprocesses_ProcessStatusId",
                table: "HistoryChangeprocesses");

            migrationBuilder.DropColumn(
                name: "ProcessStatusId",
                table: "HistoryChangeprocesses");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryProcesses_ProcessStatusId",
                table: "DisciplinaryProcesses",
                column: "ProcessStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryProcesses_ProcessStates_ProcessStatusId",
                table: "DisciplinaryProcesses",
                column: "ProcessStatusId",
                principalTable: "ProcessStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
