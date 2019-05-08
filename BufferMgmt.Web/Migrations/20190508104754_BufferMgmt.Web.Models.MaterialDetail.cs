using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BufferMgmt.Web.Migrations
{
    public partial class BufferMgmtWebModelsMaterialDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    MaterialCodeId = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: false),
                    RefLength = table.Column<int>(nullable: false),
                    BufferStock = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialDetails_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialDetails_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialDetails_MaterialCodes_MaterialCodeId",
                        column: x => x.MaterialCodeId,
                        principalTable: "MaterialCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialDetails_BranchId",
                table: "MaterialDetails",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialDetails_CustomerId",
                table: "MaterialDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialDetails_GradeId",
                table: "MaterialDetails",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialDetails_MaterialCodeId",
                table: "MaterialDetails",
                column: "MaterialCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialDetails");
        }
    }
}
