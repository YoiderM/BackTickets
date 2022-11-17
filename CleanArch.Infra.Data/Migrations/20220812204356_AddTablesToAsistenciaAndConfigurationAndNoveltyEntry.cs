using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddTablesToAsistenciaAndConfigurationAndNoveltyEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationNovelties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    Initial = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    AnticipatedNovelty = table.Column<bool>(nullable: false),
                    Assistance = table.Column<bool>(nullable: false),
                    Approbation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationNovelties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ASISTENCIA_MARCADORES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    LastCreatedByName = table.Column<string>(nullable: true),
                    LastUpdatedByName = table.Column<string>(nullable: true),
                    FECHA = table.Column<DateTime>(nullable: false),
                    DOCUMENTO = table.Column<string>(nullable: true),
                    NOMBRE = table.Column<string>(nullable: true),
                    CARGO = table.Column<string>(nullable: true),
                    ID_CENTRO_COSTO = table.Column<int>(nullable: false),
                    CENTRO_COSTO = table.Column<string>(nullable: true),
                    REQUIERELOGEO = table.Column<bool>(name: "REQUIERE LOGEO", nullable: false),
                    BIOMETRICO_CONFIRMACION = table.Column<int>(nullable: false),
                    PRESENCE_CONFIRMACION = table.Column<int>(nullable: false),
                    AVAYA_CONFIRMACION = table.Column<int>(nullable: false),
                    HERMES_CONFIRMACION = table.Column<int>(nullable: false),
                    MARCADOR = table.Column<string>(nullable: true),
                    ASISTIO = table.Column<string>(name: "¿ASISTIO?", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ASISTENCIA_MARCADORES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoveltyEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    InitDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ConfigurationNoveltiesId = table.Column<int>(nullable: false),
                    ProcessStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoveltyEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoveltyEntry_ConfigurationNovelties_ConfigurationNoveltiesId",
                        column: x => x.ConfigurationNoveltiesId,
                        principalTable: "ConfigurationNovelties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoveltyEntry_ProcessStates_ProcessStatusId",
                        column: x => x.ProcessStatusId,
                        principalTable: "ProcessStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoveltyEntry_ConfigurationNoveltiesId",
                table: "NoveltyEntry",
                column: "ConfigurationNoveltiesId");

            migrationBuilder.CreateIndex(
                name: "IX_NoveltyEntry_ProcessStatusId",
                table: "NoveltyEntry",
                column: "ProcessStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoveltyEntry");

            migrationBuilder.DropTable(
                name: "TB_ASISTENCIA_MARCADORES");

            migrationBuilder.DropTable(
                name: "ConfigurationNovelties");
        }
    }
}
