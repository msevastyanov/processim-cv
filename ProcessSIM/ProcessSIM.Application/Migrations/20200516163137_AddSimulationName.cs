using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessSIM.Application.Migrations
{
    public partial class AddSimulationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SimulationNameId",
                table: "SimulationHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "SimulationHistory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SimulationName",
                columns: table => new
                {
                    SimulationNameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimulationName", x => x.SimulationNameId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimulationHistory_SimulationNameId",
                table: "SimulationHistory",
                column: "SimulationNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimulationHistory_SimulationName_SimulationNameId",
                table: "SimulationHistory",
                column: "SimulationNameId",
                principalTable: "SimulationName",
                principalColumn: "SimulationNameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimulationHistory_SimulationName_SimulationNameId",
                table: "SimulationHistory");

            migrationBuilder.DropTable(
                name: "SimulationName");

            migrationBuilder.DropIndex(
                name: "IX_SimulationHistory_SimulationNameId",
                table: "SimulationHistory");

            migrationBuilder.DropColumn(
                name: "SimulationNameId",
                table: "SimulationHistory");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "SimulationHistory");
        }
    }
}
