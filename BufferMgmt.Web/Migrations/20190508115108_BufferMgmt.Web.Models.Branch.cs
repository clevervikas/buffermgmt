using Microsoft.EntityFrameworkCore.Migrations;

namespace BufferMgmt.Web.Migrations
{
    public partial class BufferMgmtWebModelsBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BranchName",
                table: "Branches",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BranchName",
                table: "Branches",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
