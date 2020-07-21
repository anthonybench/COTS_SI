using Microsoft.EntityFrameworkCore.Migrations;

namespace COTS_Inventory.Migrations
{
    public partial class Licensenavigations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Licence_SP_Id",
                table: "Licence",
                column: "SP_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Licence_Product_SP_Id",
                table: "Licence",
                column: "SP_Id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licence_Product_SP_Id",
                table: "Licence");

            migrationBuilder.DropIndex(
                name: "IX_Licence_SP_Id",
                table: "Licence");
        }
    }
}
