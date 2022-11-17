using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Cambiandonombredecampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "DisciplinaryProcesses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DisciplinaryProcesses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "SupportDocument",
                table: "DisciplinaryProcesses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryProcesses_UserProcessApplicantId",
                table: "DisciplinaryProcesses",
                column: "UserProcessApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryProcesses_Users_UserProcessApplicantId",
                table: "DisciplinaryProcesses",
                column: "UserProcessApplicantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryProcesses_Users_UserProcessApplicantId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaryProcesses_UserProcessApplicantId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "SupportDocument",
                table: "DisciplinaryProcesses");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "DisciplinaryProcesses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "DisciplinaryProcesses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
