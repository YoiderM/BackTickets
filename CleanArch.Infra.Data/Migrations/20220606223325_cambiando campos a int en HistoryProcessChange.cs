using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class cambiandocamposaintenHistoryProcessChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_HistoryChangeprocesses_ProcessStates_ProcessStatusId",
            //    table: "HistoryChangeprocesses");

            //migrationBuilder.DropIndex(
            //    name: "IX_HistoryChangeprocesses_ProcessStatusId",
            //    table: "HistoryChangeprocesses");

            //migrationBuilder.DropColumn(
            //    name: "ProcessStatusId",
            //    table: "HistoryChangeprocesses");

            //migrationBuilder.AlterColumn<int>(
            //    name: "StatusStart",
            //    table: "HistoryChangeprocesses",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier");

            //migrationBuilder.AlterColumn<int>(
            //    name: "StatusNext",
            //    table: "HistoryChangeprocesses",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "StatusStart",
                table: "HistoryChangeprocesses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "StatusNext",
                table: "HistoryChangeprocesses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProcessStatusId",
                table: "HistoryChangeprocesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
