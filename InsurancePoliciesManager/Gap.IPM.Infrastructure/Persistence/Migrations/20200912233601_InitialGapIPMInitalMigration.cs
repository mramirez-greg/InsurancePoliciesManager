using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gap.IPM.Infrastructure.Persistence.Migrations
{
    public partial class InitialGapIPMInitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverageType",
                columns: table => new
                {
                    CovergaeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    CoverageTypeName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageType", x => x.CovergaeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Region = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicy",
                columns: table => new
                {
                    InsurancePolicyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CovergaeTypeId = table.Column<int>(nullable: false),
                    Coverge = table.Column<int>(nullable: false),
                    CoverageStart = table.Column<DateTime>(nullable: false),
                    CoveragePeriod = table.Column<int>(nullable: false),
                    PolicyValue = table.Column<long>(nullable: false),
                    RiksType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CoverageTypeCovergaeTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicy", x => x.InsurancePolicyId);
                    table.ForeignKey(
                        name: "FK_InsurancePolicy_CoverageType_CoverageTypeCovergaeTypeId",
                        column: x => x.CoverageTypeCovergaeTypeId,
                        principalTable: "CoverageType",
                        principalColumn: "CovergaeTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInsurancePolicy",
                columns: table => new
                {
                    CustomerInsurancePolicyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<string>(maxLength: 50, nullable: false),
                    InsurancePolicyId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInsurancePolicy", x => x.CustomerInsurancePolicyId);
                    table.ForeignKey(
                        name: "FK_CustomerInsurancePolicy_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerInsurancePolicy_InsurancePolicy_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicy",
                        principalColumn: "InsurancePolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInsurancePolicy_CustomerId",
                table: "CustomerInsurancePolicy",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInsurancePolicy_InsurancePolicyId",
                table: "CustomerInsurancePolicy",
                column: "InsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicy_CoverageTypeCovergaeTypeId",
                table: "InsurancePolicy",
                column: "CoverageTypeCovergaeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInsurancePolicy");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "InsurancePolicy");

            migrationBuilder.DropTable(
                name: "CoverageType");
        }
    }
}
