using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class RenameSupplierPaymentMethodTableToSuppliersProjectsPaymentMethods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "supplier_payment_method");

            migrationBuilder.CreateTable(
                name: "suppliers_projects_payment_methods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    percentage = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    amount_concurrency = table.Column<int>(name: "amount_concurrency ", type: "int", nullable: false),
                    type_id = table.Column<int>(name: "type_id ", type: "int", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers_projects_payment_methods", x => x.id);
                    table.ForeignKey(
                        name: "FK_suppliers_projects_payment_methods_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suppliers_projects_payment_methods_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_projects_payment_methods_project_id",
                table: "suppliers_projects_payment_methods",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_projects_payment_methods_supplier_id",
                table: "suppliers_projects_payment_methods",
                column: "supplier_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "suppliers_projects_payment_methods");

            migrationBuilder.CreateTable(
                name: "supplier_payment_method",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    amount_concurrency = table.Column<int>(name: "amount_concurrency ", type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    percentage = table.Column<int>(type: "int", nullable: false),
                    type_id = table.Column<int>(name: "type_id ", type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_payment_method", x => x.id);
                    table.ForeignKey(
                        name: "FK_supplier_payment_method_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplier_payment_method_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_supplier_payment_method_project_id",
                table: "supplier_payment_method",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_payment_method_supplier_id",
                table: "supplier_payment_method",
                column: "supplier_id");
        }
    }
}
