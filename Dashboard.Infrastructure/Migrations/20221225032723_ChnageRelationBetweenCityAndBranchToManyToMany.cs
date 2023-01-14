using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Infrastructure.Migrations
{
    public partial class ChnageRelationBetweenCityAndBranchToManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Branches_BranId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_BranId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "BranId",
                table: "Cities");

            migrationBuilder.CreateTable(
                name: "CityBranchs",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityBranchs", x => new { x.CityId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_CityBranchs_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityBranchs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CityBranchs_BranchId",
                table: "CityBranchs",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityBranchs");

            migrationBuilder.AddColumn<int>(
                name: "BranId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_BranId",
                table: "Cities",
                column: "BranId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Branches_BranId",
                table: "Cities",
                column: "BranId",
                principalTable: "Branches",
                principalColumn: "Id");
        }
    }
}
