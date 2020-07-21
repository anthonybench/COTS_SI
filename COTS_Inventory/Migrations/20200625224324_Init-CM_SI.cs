using Microsoft.EntityFrameworkCore.Migrations;

namespace COTS_Inventory.Migrations
{
    public partial class InitCM_SI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientMachine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Location = table.Column<string>(maxLength: 25, nullable: false),
                    Owner = table.Column<string>(maxLength: 30, nullable: false),
                    ITSecurityPlan = table.Column<string>(maxLength: 30, nullable: true),
                    Active = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMachine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Install",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CM_Id = table.Column<int>(nullable: false),
                    SL_ID = table.Column<int>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Install", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientMachine");

            migrationBuilder.DropTable(
                name: "Install");
        }
    }
}
