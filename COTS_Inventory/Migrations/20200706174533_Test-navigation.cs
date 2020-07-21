using Microsoft.EntityFrameworkCore.Migrations;

namespace COTS_Inventory.Migrations
{
    public partial class Testnavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Test_SP_Id",
                table: "Test",
                column: "SP_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Product_SP_Id",
                table: "Test",
                column: "SP_Id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Product_SP_Id",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_SP_Id",
                table: "Test");
        }
    }
}
