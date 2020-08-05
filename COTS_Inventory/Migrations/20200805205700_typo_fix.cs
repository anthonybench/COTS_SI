using Microsoft.EntityFrameworkCore.Migrations;

namespace COTS_Inventory.Migrations
{
    public partial class typo_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Install_ClientMachine_CM_Id",
                table: "Install");

            migrationBuilder.DropForeignKey(
                name: "FK_Install_Licence_SL_Id",
                table: "Install");

            migrationBuilder.DropForeignKey(
                name: "FK_Licence_Product_SP_Id",
                table: "Licence");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Vendor_SV_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Product_SP_Id",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Licence",
                table: "Licence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Install",
                table: "Install");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientMachine",
                table: "ClientMachine");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Vendors");

            migrationBuilder.RenameTable(
                name: "Test",
                newName: "Tests");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Licence",
                newName: "Licenses");

            migrationBuilder.RenameTable(
                name: "Install",
                newName: "Installs");

            migrationBuilder.RenameTable(
                name: "ClientMachine",
                newName: "ClientMachines");

            migrationBuilder.RenameIndex(
                name: "IX_Test_SP_Id",
                table: "Tests",
                newName: "IX_Tests_SP_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_SV_Id",
                table: "Products",
                newName: "IX_Products_SV_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Licence_SP_Id",
                table: "Licenses",
                newName: "IX_Licenses_SP_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Install_SL_Id",
                table: "Installs",
                newName: "IX_Installs_SL_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Install_CM_Id",
                table: "Installs",
                newName: "IX_Installs_CM_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Installs",
                table: "Installs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientMachines",
                table: "ClientMachines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Installs_ClientMachines_CM_Id",
                table: "Installs",
                column: "CM_Id",
                principalTable: "ClientMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Installs_Licenses_SL_Id",
                table: "Installs",
                column: "SL_Id",
                principalTable: "Licenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Products_SP_Id",
                table: "Licenses",
                column: "SP_Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Vendors_SV_Id",
                table: "Products",
                column: "SV_Id",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Products_SP_Id",
                table: "Tests",
                column: "SP_Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installs_ClientMachines_CM_Id",
                table: "Installs");

            migrationBuilder.DropForeignKey(
                name: "FK_Installs_Licenses_SL_Id",
                table: "Installs");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Products_SP_Id",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Vendors_SV_Id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Products_SP_Id",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Installs",
                table: "Installs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientMachines",
                table: "ClientMachines");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "Vendor");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "Test");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Licenses",
                newName: "Licence");

            migrationBuilder.RenameTable(
                name: "Installs",
                newName: "Install");

            migrationBuilder.RenameTable(
                name: "ClientMachines",
                newName: "ClientMachine");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_SP_Id",
                table: "Test",
                newName: "IX_Test_SP_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SV_Id",
                table: "Product",
                newName: "IX_Product_SV_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_SP_Id",
                table: "Licence",
                newName: "IX_Licence_SP_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Installs_SL_Id",
                table: "Install",
                newName: "IX_Install_SL_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Installs_CM_Id",
                table: "Install",
                newName: "IX_Install_CM_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test",
                table: "Test",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Licence",
                table: "Licence",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Install",
                table: "Install",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientMachine",
                table: "ClientMachine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Install_ClientMachine_CM_Id",
                table: "Install",
                column: "CM_Id",
                principalTable: "ClientMachine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Install_Licence_SL_Id",
                table: "Install",
                column: "SL_Id",
                principalTable: "Licence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licence_Product_SP_Id",
                table: "Licence",
                column: "SP_Id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Vendor_SV_Id",
                table: "Product",
                column: "SV_Id",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Product_SP_Id",
                table: "Test",
                column: "SP_Id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
