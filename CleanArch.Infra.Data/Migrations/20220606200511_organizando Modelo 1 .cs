using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class organizandoModelo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            //migrationBuilder.CreateTable(
            //    name: "DisciplinaryProcesses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedAt = table.Column<DateTime>(nullable: true),
            //        UpdatedAt = table.Column<DateTime>(nullable: true),
            //        DeletedAt = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<Guid>(nullable: true),
            //        UpdatedBy = table.Column<Guid>(nullable: true),
            //        LastCreatedByName = table.Column<string>(nullable: true),
            //        LastUpdatedByName = table.Column<string>(nullable: true),
            //        UserId = table.Column<Guid>(nullable: false),
            //        UserProcessApplicantId = table.Column<Guid>(nullable: false),
            //        StatusDate = table.Column<DateTime>(nullable: false),
            //        CampaignName = table.Column<string>(nullable: true),
            //        Job = table.Column<string>(nullable: true),
            //        DescriptionOfTheFault = table.Column<string>(nullable: true),
            //        DocumentName = table.Column<string>(nullable: true),
            //        LegalSupportDocument = table.Column<string>(nullable: true),
            //        TypeOfFaultId = table.Column<Guid>(nullable: false),
            //        ProcessStatusId = table.Column<Guid>(nullable: false)
            //    }
                //,
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_DisciplinaryProcesses", x => x.Id);
                //    table.ForeignKey(
                //        name: "FK_DisciplinaryProcesses_ProcessStates_ProcessStatusId",
                //        column: x => x.ProcessStatusId,
                //        principalTable: "ProcessStates",
                //        principalColumn: "Id",
                //        onDelete: ReferentialAction.Cascade);
                //    table.ForeignKey(
                //        name: "FK_DisciplinaryProcesses_TypesOfFaults_TypeOfFaultId",
                //        column: x => x.TypeOfFaultId,
                //        principalTable: "TypesOfFaults",
                //        principalColumn: "Id",
                //        onDelete: ReferentialAction.Cascade);
                //}
                //);

            //migrationBuilder.CreateTable(
            //    name: "HistoryChangeprocesses",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        CreatedAt = table.Column<DateTime>(nullable: true),
            //        UpdatedAt = table.Column<DateTime>(nullable: true),
            //        DeletedAt = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<Guid>(nullable: true),
            //        UpdatedBy = table.Column<Guid>(nullable: true),
            //        CreatedByName = table.Column<string>(nullable: true),
            //        UpdatedByName = table.Column<string>(nullable: true),
            //        StatusDate = table.Column<DateTime>(nullable: false),
            //        Status = table.Column<bool>(nullable: false),
            //        StatusStart = table.Column<Guid>(nullable: false),
            //        StatusNext = table.Column<Guid>(nullable: false),
            //        ProcessPerformedById = table.Column<Guid>(nullable: false),
            //        DisciplinaryProcessId = table.Column<int>(nullable: false)
            //    }
                //,
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_HistoryChangeprocesses", x => x.Id);
                //    table.ForeignKey(
                //        name: "FK_HistoryChangeprocesses_DisciplinaryProcesses_DisciplinaryProcessId",
                //        column: x => x.DisciplinaryProcessId,
                //        principalTable: "DisciplinaryProcesses",
                //        principalColumn: "Id",
                //        onDelete: ReferentialAction.Cascade);
                //}
                //);

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryProcesses_ProcessStatusId",
                table: "DisciplinaryProcesses",
                column: "ProcessStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryProcesses_TypeOfFaultId",
                table: "DisciplinaryProcesses",
                column: "TypeOfFaultId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChangeprocesses_DisciplinaryProcessId",
                table: "HistoryChangeprocesses",
                column: "DisciplinaryProcessId");
            //migrationBuilder.DropForeignKey(
            //    name: "FK_DisciplinaryProcesses_TypesOfFaults_TypeOfFaultId",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.DropIndex(
            //    name: "IX_DisciplinaryProcesses_TypeOfFaultId",
            //    table: "DisciplinaryProcesses");

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "UserProcessApplicantId",
            //    table: "DisciplinaryProcesses",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "TypeOfFaultId",
            //    table: "DisciplinaryProcesses",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ProcessStatusId",
            //    table: "DisciplinaryProcesses",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<Guid>(
            //    name: "ProcessStatusId1",
            //    table: "DisciplinaryProcesses",
            //    nullable: true);

            //migrationBuilder.AddColumn<Guid>(
            //    name: "TypeOfFaultId1",
            //    table: "DisciplinaryProcesses",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_DisciplinaryProcesses_ProcessStatusId1",
            //    table: "DisciplinaryProcesses",
            //    column: "ProcessStatusId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DisciplinaryProcesses_TypeOfFaultId1",
            //    table: "DisciplinaryProcesses",
            //    column: "TypeOfFaultId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_DisciplinaryProcesses_ProcessStates_ProcessStatusId1",
            //    table: "DisciplinaryProcesses",
            //    column: "ProcessStatusId1",
            //    principalTable: "ProcessStates",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_DisciplinaryProcesses_TypesOfFaults_TypeOfFaultId1",
            //    table: "DisciplinaryProcesses",
            //    column: "TypeOfFaultId1",
            //    principalTable: "TypesOfFaults",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryProcesses_ProcessStates_ProcessStatusId1",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryProcesses_TypesOfFaults_TypeOfFaultId1",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaryProcesses_ProcessStatusId1",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaryProcesses_TypeOfFaultId1",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "ProcessStatusId1",
                table: "DisciplinaryProcesses");

            migrationBuilder.DropColumn(
                name: "TypeOfFaultId1",
                table: "DisciplinaryProcesses");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserProcessApplicantId",
                table: "DisciplinaryProcesses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeOfFaultId",
                table: "DisciplinaryProcesses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessStatusId",
                table: "DisciplinaryProcesses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryProcesses_TypeOfFaultId",
                table: "DisciplinaryProcesses",
                column: "TypeOfFaultId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryProcesses_TypesOfFaults_TypeOfFaultId",
                table: "DisciplinaryProcesses",
                column: "TypeOfFaultId",
                principalTable: "TypesOfFaults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
