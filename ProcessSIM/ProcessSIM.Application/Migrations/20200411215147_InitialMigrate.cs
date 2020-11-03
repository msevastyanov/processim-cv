using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessSIM.Application.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceCategory",
                columns: table => new
                {
                    ResourceCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceCategory", x => x.ResourceCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ResourceType",
                columns: table => new
                {
                    ResourceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceTypeName = table.Column<string>(nullable: true),
                    ResourceCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.ResourceTypeId);
                    table.ForeignKey(
                        name: "FK_ResourceType_ResourceCategory_ResourceCategoryId",
                        column: x => x.ResourceCategoryId,
                        principalTable: "ResourceCategory",
                        principalColumn: "ResourceCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(nullable: true),
                    ResourceTypeId = table.Column<int>(nullable: true),
                    ResourceCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceCategory_ResourceCategoryId",
                        column: x => x.ResourceCategoryId,
                        principalTable: "ResourceCategory",
                        principalColumn: "ResourceCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceType_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceType",
                        principalColumn: "ResourceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceParameter",
                columns: table => new
                {
                    ResourceParameterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceParameterName = table.Column<int>(nullable: false),
                    ResourceParameterAlias = table.Column<int>(nullable: false),
                    ResourceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceParameter", x => x.ResourceParameterId);
                    table.ForeignKey(
                        name: "FK_ResourceParameter_ResourceType_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceType",
                        principalColumn: "ResourceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceParameterValue",
                columns: table => new
                {
                    ResourceParameterValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterValue = table.Column<string>(nullable: true),
                    ResourceParameterId = table.Column<int>(nullable: true),
                    ResourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceParameterValue", x => x.ResourceParameterValueId);
                    table.ForeignKey(
                        name: "FK_ResourceParameterValue_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResourceParameterValue_ResourceParameter_ResourceParameterId",
                        column: x => x.ResourceParameterId,
                        principalTable: "ResourceParameter",
                        principalColumn: "ResourceParameterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceCategoryId",
                table: "Resource",
                column: "ResourceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceTypeId",
                table: "Resource",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceParameter_ResourceTypeId",
                table: "ResourceParameter",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceParameterValue_ResourceId",
                table: "ResourceParameterValue",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceParameterValue_ResourceParameterId",
                table: "ResourceParameterValue",
                column: "ResourceParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceType_ResourceCategoryId",
                table: "ResourceType",
                column: "ResourceCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceParameterValue");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "ResourceParameter");

            migrationBuilder.DropTable(
                name: "ResourceType");

            migrationBuilder.DropTable(
                name: "ResourceCategory");
        }
    }
}
