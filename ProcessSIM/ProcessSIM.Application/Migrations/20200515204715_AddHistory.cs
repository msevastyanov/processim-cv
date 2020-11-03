using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessSIM.Application.Migrations
{
    public partial class AddHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimulationHistory",
                columns: table => new
                {
                    SimulationHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimulationHistory", x => x.SimulationHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureHistory",
                columns: table => new
                {
                    ProcedureHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureName = table.Column<string>(nullable: true),
                    ProcedureId = table.Column<int>(nullable: false),
                    StartTime = table.Column<int>(nullable: false),
                    EndTime = table.Column<int>(nullable: false),
                    WaitingTime = table.Column<int>(nullable: false),
                    SimulationHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureHistory", x => x.ProcedureHistoryId);
                    table.ForeignKey(
                        name: "FK_ProcedureHistory_SimulationHistory_SimulationHistoryId",
                        column: x => x.SimulationHistoryId,
                        principalTable: "SimulationHistory",
                        principalColumn: "SimulationHistoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceHistory",
                columns: table => new
                {
                    ResourceHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(nullable: true),
                    ResourceId = table.Column<int>(nullable: false),
                    UseTime = table.Column<int>(nullable: false),
                    Downtime = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    SimulationHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceHistory", x => x.ResourceHistoryId);
                    table.ForeignKey(
                        name: "FK_ResourceHistory_SimulationHistory_SimulationHistoryId",
                        column: x => x.SimulationHistoryId,
                        principalTable: "SimulationHistory",
                        principalColumn: "SimulationHistoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RandomEventHistory",
                columns: table => new
                {
                    RandomEventHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandomEventName = table.Column<string>(nullable: true),
                    RandomEventId = table.Column<int>(nullable: false),
                    StartTime = table.Column<int>(nullable: false),
                    EndTime = table.Column<int>(nullable: false),
                    ProcedureHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomEventHistory", x => x.RandomEventHistoryId);
                    table.ForeignKey(
                        name: "FK_RandomEventHistory_ProcedureHistory_ProcedureHistoryId",
                        column: x => x.ProcedureHistoryId,
                        principalTable: "ProcedureHistory",
                        principalColumn: "ProcedureHistoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceUseHistory",
                columns: table => new
                {
                    ResourceUseHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<int>(nullable: false),
                    EndTime = table.Column<int>(nullable: false),
                    ResourceHistoryId = table.Column<int>(nullable: true),
                    SimulationHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUseHistory", x => x.ResourceUseHistoryId);
                    table.ForeignKey(
                        name: "FK_ResourceUseHistory_ResourceHistory_ResourceHistoryId",
                        column: x => x.ResourceHistoryId,
                        principalTable: "ResourceHistory",
                        principalColumn: "ResourceHistoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResourceUseHistory_SimulationHistory_SimulationHistoryId",
                        column: x => x.SimulationHistoryId,
                        principalTable: "SimulationHistory",
                        principalColumn: "SimulationHistoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureHistory_SimulationHistoryId",
                table: "ProcedureHistory",
                column: "SimulationHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RandomEventHistory_ProcedureHistoryId",
                table: "RandomEventHistory",
                column: "ProcedureHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceHistory_SimulationHistoryId",
                table: "ResourceHistory",
                column: "SimulationHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUseHistory_ResourceHistoryId",
                table: "ResourceUseHistory",
                column: "ResourceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUseHistory_SimulationHistoryId",
                table: "ResourceUseHistory",
                column: "SimulationHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandomEventHistory");

            migrationBuilder.DropTable(
                name: "ResourceUseHistory");

            migrationBuilder.DropTable(
                name: "ProcedureHistory");

            migrationBuilder.DropTable(
                name: "ResourceHistory");

            migrationBuilder.DropTable(
                name: "SimulationHistory");
        }
    }
}
