using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AñadirrelacionesFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {          

            migrationBuilder.AlterColumn<string>(
                name: "AuthObservation",
                table: "OvertimeDetails",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminObservation",
                table: "OvertimeDetails",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_OvertimeDetails_CostCenters_CostCenterId",
                table: "OvertimeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OvertimeDetails_OvertimePeriods_OvertimePeriodId",
                table: "OvertimeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OvertimeDetails_OvertimeTypes_OvertimeTypeId",
                table: "OvertimeDetails");

            migrationBuilder.AlterColumn<string>(
                name: "AuthObservation",
                table: "OvertimeDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminObservation",
                table: "OvertimeDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
