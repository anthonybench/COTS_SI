using Microsoft.EntityFrameworkCore.Migrations;

namespace COTS_Inventory.Migrations
{
    public partial class Installnavigations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Install_CM_Id",
                table: "Install",
                column: "CM_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Install_SL_Id",
                table: "Install",
                column: "SL_Id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Install_ClientMachine_CM_Id",
                table: "Install");

            migrationBuilder.DropForeignKey(
                name: "FK_Install_Licence_SL_Id",
                table: "Install");

            migrationBuilder.DropIndex(
                name: "IX_Install_CM_Id",
                table: "Install");

            migrationBuilder.DropIndex(
                name: "IX_Install_SL_Id",
                table: "Install");
        }
    }
}
