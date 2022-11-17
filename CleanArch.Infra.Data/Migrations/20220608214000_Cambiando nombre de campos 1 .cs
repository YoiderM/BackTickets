using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Cambiandonombredecampos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryProcesses_Users_UserProcessApplicantId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaryProcesses_UserProcessApplicantId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "UserProcessApplicantId",
                table: "DisciplinaryProcesses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserProcessApplicantId",
                table: "DisciplinaryProcesses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
