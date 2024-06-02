using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class AddProjectSupplierTaxeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_suppliers_taxe_tax_id",
                table: "projects_suppliers");

            migrationBuilder.DropIndex(
                name: "IX_projects_suppliers_tax_id",
                table: "projects_suppliers");

            migrationBuilder.DropColumn(
                name: "tax_id",
                table: "projects_suppliers");

            migrationBuilder.CreateTable(
                name: "projects_suppliers_taxes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    taxe_id = table.Column<int>(type: "int", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects_suppliers_taxes", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_suppliers_taxes_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projects_suppliers_taxes_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projects_suppliers_taxes_taxe_taxe_id",
                        column: x => x.taxe_id,
                        principalTable: "taxe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projects_suppliers_taxes_project_id",
                table: "projects_suppliers_taxes",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_suppliers_taxes_supplier_id",
                table: "projects_suppliers_taxes",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_suppliers_taxes_taxe_id",
                table: "projects_suppliers_taxes",
                column: "taxe_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projects_suppliers_taxes");

            migrationBuilder.AddColumn<int>(
                name: "tax_id",
                table: "projects_suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_projects_suppliers_tax_id",
                table: "projects_suppliers",
                column: "tax_id");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_suppliers_taxe_tax_id",
                table: "projects_suppliers",
                column: "tax_id",
                principalTable: "taxe",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
