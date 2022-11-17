using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class OrganizandoModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_DisciplinaryProcesses_ProcessStates_ProcessStatusId1",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_DisciplinaryProcesses_TypesOfFaults_TypeOfFaultId1",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_HistoryChangeprocesses_DisciplinaryProcesses_DisciplinaryProcessId",
            //    table: "HistoryChangeprocesses");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_HistoryChangeprocesses_ProcessStates_ProcessStatusId",
            //    table: "HistoryChangeprocesses");

            //migrationBuilder.DropIndex(
            //    name: "IX_HistoryChangeprocesses_DisciplinaryProcessId",
            //    table: "HistoryChangeprocesses");

            //migrationBuilder.DropIndex(
            //    name: "IX_HistoryChangeprocesses_ProcessStatusId",
            //    table: "HistoryChangeprocesses");

            //migrationBuilder.DropIndex(
            //    name: "IX_DisciplinaryProcesses_ProcessStatusId1",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.DropIndex(
            //    name: "IX_DisciplinaryProcesses_TypeOfFaultId1",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.DropColumn(
            //    name: "CreatedByName",
            //    table: "TypesOfFaults");

            //migrationBuilder.DropColumn(
            //    name: "UpdatedByName",
            //    table: "TypesOfFaults");

            //migrationBuilder.DropColumn(
            //    name: "CreatedByName",
            //    table: "ProcessStates");

            //migrationBuilder.DropColumn(
            //    name: "UpdatedByName",
            //    table: "ProcessStates");

            //migrationBuilder.DropColumn(
            //    name: "DisciplinaryProcessId",
            //    table: "HistoryChangeprocesses");

            //migrationBuilder.DropColumn(
            //    name: "ProcessStatusId",
            //    table: "HistoryChangeprocesses");

            //migrationBuilder.DropColumn(
            //    name: "ProcessStatusId",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.DropColumn(
            //    name: "ProcessStatusId1",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.DropColumn(
            //    name: "TypeOfFaultId",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.DropColumn(
            //    name: "TypeOfFaultId1",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "TypesOfFaults",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<string>(
            //    name: "LastCreatedByName",
            //    table: "TypesOfFaults",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "LastUpdatedByName",
            //    table: "TypesOfFaults",
            //    nullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "ProcessStates",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<string>(
            //    name: "LastCreatedByName",
            //    table: "ProcessStates",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "LastUpdatedByName",
            //    table: "ProcessStates",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "ProcessStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    NameStatus = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                }
                //,
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_ProcessStates", x => x.Id);
                //}
                );

            migrationBuilder.CreateTable(
                name: "TypesOfFaults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true),
                    NameOfFault = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                }
                //,
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_TypesOfFaults", x => x.Id);
                //}
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastCreatedByName",
                table: "TypesOfFaults");

            migrationBuilder.DropColumn(
                name: "LastUpdatedByName",
                table: "TypesOfFaults");

            migrationBuilder.DropColumn(
                name: "LastCreatedByName",
                table: "ProcessStates");

            migrationBuilder.DropColumn(
                name: "LastUpdatedByName",
                table: "ProcessStates");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TypesOfFaults",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "TypesOfFaults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByName",
                table: "TypesOfFaults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProcessStates",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "ProcessStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByName",
                table: "ProcessStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaryProcessId",
                table: "HistoryChangeprocesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProcessStatusId",
                table: "HistoryChangeprocesses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ProcessStatusId",
                table: "DisciplinaryProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProcessStatusId1",
                table: "DisciplinaryProcesses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfFaultId",
                table: "DisciplinaryProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeOfFaultId1",
                table: "DisciplinaryProcesses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChangeprocesses_DisciplinaryProcessId",
                table: "HistoryChangeprocesses",
                column: "DisciplinaryProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChangeprocesses_ProcessStatusId",
                table: "HistoryChangeprocesses",
                column: "ProcessStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryProcesses_ProcessStatusId1",
                table: "DisciplinaryProcesses",
                column: "ProcessStatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryProcesses_TypeOfFaultId1",
                table: "DisciplinaryProcesses",
                column: "TypeOfFaultId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryProcesses_ProcessStates_ProcessStatusId1",
                table: "DisciplinaryProcesses",
                column: "ProcessStatusId1",
                principalTable: "ProcessStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryProcesses_TypesOfFaults_TypeOfFaultId1",
                table: "DisciplinaryProcesses",
                column: "TypeOfFaultId1",
                principalTable: "TypesOfFaults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryChangeprocesses_DisciplinaryProcesses_DisciplinaryProcessId",
                table: "HistoryChangeprocesses",
                column: "DisciplinaryProcessId",
                principalTable: "DisciplinaryProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
