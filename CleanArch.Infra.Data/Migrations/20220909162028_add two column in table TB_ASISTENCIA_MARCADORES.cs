using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class addtwocolumnintableTB_ASISTENCIA_MARCADORES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRIPCION",
                table: "TB_ASISTENCIA_MARCADORES",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HORA_INICIO_TURNO",
                table: "TB_ASISTENCIA_MARCADORES",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRIPCION",
                table: "TB_ASISTENCIA_MARCADORES");

            migrationBuilder.DropColumn(
                name: "HORA_INICIO_TURNO",
                table: "TB_ASISTENCIA_MARCADORES");
        }
    }
}
