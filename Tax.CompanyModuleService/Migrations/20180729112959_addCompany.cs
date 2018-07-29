using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tax.CompanyModuleService.Migrations
{
    public partial class addCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shareholder_Companies_CompanyId",
                table: "Shareholder");

            migrationBuilder.DropTable(
                name: "TbCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompayId = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    AccountType = table.Column<int>(nullable: false),
                    LinkMan = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    OpenBankName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    SealExplation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Shareholder_Company_CompanyId",
                table: "Shareholder",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shareholder_Company_CompanyId",
                table: "Shareholder");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TbCompany",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Addr = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCompany", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Shareholder_Companies_CompanyId",
                table: "Shareholder",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
