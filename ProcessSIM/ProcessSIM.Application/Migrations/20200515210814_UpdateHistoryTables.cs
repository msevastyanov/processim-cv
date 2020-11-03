using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessSIM.Application.Migrations
{
    public partial class UpdateHistoryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceUseHistory_SimulationHistory_SimulationHistoryId",
                table: "ResourceUseHistory");

            migrationBuilder.DropIndex(
                name: "IX_ResourceUseHistory_SimulationHistoryId",
                table: "ResourceUseHistory");

            migrationBuilder.DropColumn(
                name: "SimulationHistoryId",
                table: "ResourceUseHistory");

            migrationBuilder.DropColumn(
                name: "RandomEventId",
                table: "RandomEventHistory");

            migrationBuilder.DropColumn(
                name: "RandomEventName",
                table: "RandomEventHistory");

            migrationBuilder.DropColumn(
                name: "ProcedureId",
                table: "ProcedureHistory");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "ResourceHistory",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EventAlias",
                table: "RandomEventHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "RandomEventHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcedureAlias",
                table: "ProcedureHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventAlias",
                table: "RandomEventHistory");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "RandomEventHistory");

            migrationBuilder.DropColumn(
                name: "ProcedureAlias",
                table: "ProcedureHistory");

            migrationBuilder.AddColumn<int>(
                name: "SimulationHistoryId",
                table: "ResourceUseHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "ResourceHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "RandomEventId",
                table: "RandomEventHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RandomEventName",
                table: "RandomEventHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcedureId",
                table: "ProcedureHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUseHistory_SimulationHistoryId",
                table: "ResourceUseHistory",
                column: "SimulationHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceUseHistory_SimulationHistory_SimulationHistoryId",
                table: "ResourceUseHistory",
                column: "SimulationHistoryId",
                principalTable: "SimulationHistory",
                principalColumn: "SimulationHistoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
