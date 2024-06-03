using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class RenameTaxTableAndAddDateColumnToProjectPaymentMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_suppliers_taxes_taxe_taxe_id",
                table: "projects_suppliers_taxes");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_taxes_taxe_taxe_id",
                table: "projects_taxes");

            migrationBuilder.DropTable(
                name: "taxe");

            migrationBuilder.RenameColumn(
                name: "taxe_id",
                table: "projects_taxes",
                newName: "tax_id");

            migrationBuilder.RenameIndex(
                name: "IX_projects_taxes_taxe_id",
                table: "projects_taxes",
                newName: "IX_projects_taxes_tax_id");

            migrationBuilder.RenameColumn(
                name: "taxe_id",
                table: "projects_suppliers_taxes",
                newName: "tax_id");

            migrationBuilder.RenameIndex(
                name: "IX_projects_suppliers_taxes_taxe_id",
                table: "projects_suppliers_taxes",
                newName: "IX_projects_suppliers_taxes_tax_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "project_payment_method",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "tax",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tax", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_projects_suppliers_taxes_tax_tax_id",
                table: "projects_suppliers_taxes",
                column: "tax_id",
                principalTable: "tax",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_taxes_tax_tax_id",
                table: "projects_taxes",
                column: "tax_id",
                principalTable: "tax",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_suppliers_taxes_tax_tax_id",
                table: "projects_suppliers_taxes");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_taxes_tax_tax_id",
                table: "projects_taxes");

            migrationBuilder.DropTable(
                name: "tax");

            migrationBuilder.DropColumn(
                name: "date",
                table: "project_payment_method");

            migrationBuilder.RenameColumn(
                name: "tax_id",
                table: "projects_taxes",
                newName: "taxe_id");

            migrationBuilder.RenameIndex(
                name: "IX_projects_taxes_tax_id",
                table: "projects_taxes",
                newName: "IX_projects_taxes_taxe_id");

            migrationBuilder.RenameColumn(
                name: "tax_id",
                table: "projects_suppliers_taxes",
                newName: "taxe_id");

            migrationBuilder.RenameIndex(
                name: "IX_projects_suppliers_taxes_tax_id",
                table: "projects_suppliers_taxes",
                newName: "IX_projects_suppliers_taxes_taxe_id");

            migrationBuilder.CreateTable(
                name: "taxe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxe", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_projects_suppliers_taxes_taxe_taxe_id",
                table: "projects_suppliers_taxes",
                column: "taxe_id",
                principalTable: "taxe",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_taxes_taxe_taxe_id",
                table: "projects_taxes",
                column: "taxe_id",
                principalTable: "taxe",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
