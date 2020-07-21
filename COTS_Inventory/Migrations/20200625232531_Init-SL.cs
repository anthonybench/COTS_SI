using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COTS_Inventory.Migrations
{
    public partial class InitSL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SP_Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 25, nullable: false),
                    Servicer = table.Column<string>(maxLength: 30, nullable: false),
                    NumOfInstalls = table.Column<int>(nullable: false),
                    Cost = table.Column<string>(maxLength: 25, nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    PurchaseOrderNum = table.Column<string>(maxLength: 25, nullable: false),
                    MRNumber = table.Column<string>(maxLength: 25, nullable: true),
                    PurchaseAgent = table.Column<string>(maxLength: 30, nullable: true),
                    Owner = table.Column<string>(maxLength: 30, nullable: false),
                    OwnerEmail = table.Column<string>(maxLength: 50, nullable: true),
                    ActivationWebsite = table.Column<string>(maxLength: 50, nullable: true),
                    ContractNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licence", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licence");
        }
    }
}
