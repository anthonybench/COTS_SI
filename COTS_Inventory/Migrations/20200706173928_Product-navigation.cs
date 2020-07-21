using Microsoft.EntityFrameworkCore.Migrations;

namespace COTS_Inventory.Migrations
{
    public partial class Productnavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_SV_Id",
                table: "Product",
                column: "SV_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Vendor_SV_Id",
                table: "Product",
                column: "SV_Id",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Vendor_SV_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SV_Id",
                table: "Product");
        }
    }
}
