using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AgregandocamposalatabladisciplinaryProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "userProcessApprovingId",
                table: "DisciplinaryProcesses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "userProcessAuthorizingId",
                table: "DisciplinaryProcesses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userProcessApprovingId",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "userProcessAuthorizingId",
                table: "DisciplinaryProcesses");
        }
    }
}
