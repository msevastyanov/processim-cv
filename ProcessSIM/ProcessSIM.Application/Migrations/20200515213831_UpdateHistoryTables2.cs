using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessSIM.Application.Migrations
{
    public partial class UpdateHistoryTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Complexity",
                table: "SimulationHistory",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "WaitingTime",
                table: "SimulationHistory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complexity",
                table: "SimulationHistory");

            migrationBuilder.DropColumn(
                name: "WaitingTime",
                table: "SimulationHistory");
        }
    }
}
