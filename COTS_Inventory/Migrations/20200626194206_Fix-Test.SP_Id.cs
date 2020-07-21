using Microsoft.EntityFrameworkCore.Migrations;

namespace COTS_Inventory.Migrations
{
    public partial class FixTestSP_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SP_ID",
                table: "Test",
                newName: "SP_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SP_Id",
                table: "Test",
                newName: "SP_ID");
        }
    }
}
