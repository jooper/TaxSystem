using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tax.CompanyModuleService.Migrations
{
    public partial class migrationFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BusinessState = table.Column<int>(nullable: false),
                    TaxNumber = table.Column<string>(nullable: true),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    RegisterCapital = table.Column<double>(nullable: false),
                    Addr = table.Column<string>(nullable: true),
                    LinkMan = table.Column<string>(nullable: true),
                    LinkManPhone = table.Column<int>(nullable: false),
                    LegalPerson = table.Column<string>(nullable: true),
                    LegalPersonPhone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCompany",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Addr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shareholder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IDNumber = table.Column<string>(nullable: true),
                    Percent = table.Column<double>(nullable: false),
                    TaxpayerType = table.Column<int>(nullable: false),
                    RigsterAddr = table.Column<string>(nullable: true),
                    NationalTaxState = table.Column<string>(nullable: true),
                    NationalTaxLogoffDes = table.Column<string>(nullable: true),
                    LandTaxState = table.Column<string>(nullable: true),
                    LandTaxLogoffDes = table.Column<string>(nullable: true),
                    HaveElectronicTax = table.Column<bool>(nullable: false),
                    ElectronicTaxAccount = table.Column<bool>(nullable: false),
                    ElectronicTaxPwd = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shareholder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shareholder_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shareholder_CompanyId",
                table: "Shareholder",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shareholder");

            migrationBuilder.DropTable(
                name: "TbCompany");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
