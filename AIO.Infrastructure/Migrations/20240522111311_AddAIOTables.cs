using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class AddAIOTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insurance_condition",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    percentage = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    period = table.Column<int>(type: "int", nullable: false),
                    type_id = table.Column<int>(name: "type_id ", type: "int", nullable: false),
                    amount_concurrency_type = table.Column<int>(name: "amount_concurrency_type ", type: "int", nullable: false),
                    status_id = table.Column<int>(name: "status_id ", type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_condition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoice_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    responsible_person_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    responsible_person_phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    responsible_person_job = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    responsible_person_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_method",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    percentage = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    amount_concurrency = table.Column<int>(name: "amount_concurrency ", type: "int", nullable: false),
                    type_id = table.Column<int>(name: "type_id ", type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_method", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    responsible_person_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    responsible_person_phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    responsible_person_job = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    responsible_person_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "taxe",
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
                    table.PrimaryKey("PK_taxe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "owners_attachments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    uid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    media_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners_attachments", x => x.id);
                    table.ForeignKey(
                        name: "FK_owners_attachments_owners_owner_id",
                        column: x => x.owner_id,
                        principalTable: "owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "supplier_payment_method",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    payment_method_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_payment_method", x => x.id);
                    table.ForeignKey(
                        name: "FK_supplier_payment_method_payment_method_payment_method_id",
                        column: x => x.payment_method_id,
                        principalTable: "payment_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplier_payment_method_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suppliers_attachments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    uid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    media_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers_attachments", x => x.id);
                    table.ForeignKey(
                        name: "FK_suppliers_attachments_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suppliers_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_suppliers_categories_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suppliers_categories_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contract_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    po_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Assigned_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    assigned_to_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    primary_reciept_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    final_reciept_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_price_concurrency = table.Column<int>(type: "int", nullable: false),
                    limit_of_liability = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    project_profitability_ratio = table.Column<int>(type: "int", nullable: true),
                    implementation_period = table.Column<int>(type: "int", nullable: false),
                    insurance_period = table.Column<int>(type: "int", nullable: false),
                    payment_condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_new = table.Column<bool>(type: "bit", nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    project_type_id = table.Column<int>(name: "project_type_id ", type: "int", nullable: false),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    tax_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_owners_owner_id",
                        column: x => x.owner_id,
                        principalTable: "owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projects_projects_parent_id",
                        column: x => x.parent_id,
                        principalTable: "projects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_projects_taxe_tax_id",
                        column: x => x.tax_id,
                        principalTable: "taxe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoice_number = table.Column<int>(type: "int", nullable: false),
                    is_paid = table.Column<bool>(type: "bit", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    collectin_type_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoices_owners_owner_id",
                        column: x => x.owner_id,
                        principalTable: "owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoices_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "project_payment_method",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_method_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_payment_method", x => x.id);
                    table.ForeignKey(
                        name: "FK_project_payment_method_payment_method_payment_method_id",
                        column: x => x.payment_method_id,
                        principalTable: "payment_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_project_payment_method_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "projects_attachments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    uid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    media_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects_attachments", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_attachments_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "projects_insurances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    insurance_condition_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects_insurances", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_insurances_insurance_condition_insurance_condition_id",
                        column: x => x.insurance_condition_id,
                        principalTable: "insurance_condition",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projects_insurances_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "projects_suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contract_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    primary_reciept_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    final_reciept_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_price_concurrency = table.Column<int>(type: "int", nullable: false),
                    implementation_period = table.Column<int>(type: "int", nullable: false),
                    insurance_period = table.Column<int>(type: "int", nullable: false),
                    payment_condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tax_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects_suppliers", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_suppliers_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projects_suppliers_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projects_suppliers_taxe_tax_id",
                        column: x => x.tax_id,
                        principalTable: "taxe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "statement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statement_number = table.Column<int>(type: "int", nullable: false),
                    is_paid = table.Column<bool>(type: "bit", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    collectin_type_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statement", x => x.id);
                    table.ForeignKey(
                        name: "FK_statement_owners_owner_id",
                        column: x => x.owner_id,
                        principalTable: "owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_statement_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suppliers_project_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers_project_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_suppliers_project_items_items_item_id",
                        column: x => x.item_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suppliers_project_items_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suppliers_project_items_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suppliers_projects_insurances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    insurance_condition_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers_projects_insurances", x => x.id);
                    table.ForeignKey(
                        name: "FK_suppliers_projects_insurances_insurance_condition_insurance_condition_id",
                        column: x => x.insurance_condition_id,
                        principalTable: "insurance_condition",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suppliers_projects_insurances_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suppliers_projects_insurances_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoice_payment_order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    discount_value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    invoice_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_payment_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoice_payment_order_invoices_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "invoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoice_payment_order_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "projects_suppliers_attachments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_supplier_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    uid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    media_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects_suppliers_attachments", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_suppliers_attachments_projects_suppliers_project_supplier_id",
                        column: x => x.project_supplier_id,
                        principalTable: "projects_suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "statement_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statement_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statement_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_statement_category_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_statement_category_statement_statement_id",
                        column: x => x.statement_id,
                        principalTable: "statement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoice_payment_order_invoice_id",
                table: "invoice_payment_order",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_payment_order_project_id",
                table: "invoice_payment_order",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_owner_id",
                table: "invoices",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_project_id",
                table: "invoices",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_owners_attachments_owner_id",
                table: "owners_attachments",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_payment_method_payment_method_id",
                table: "project_payment_method",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_payment_method_project_id",
                table: "project_payment_method",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_owner_id",
                table: "projects",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_parent_id",
                table: "projects",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_tax_id",
                table: "projects",
                column: "tax_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_attachments_project_id",
                table: "projects_attachments",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_insurances_insurance_condition_id",
                table: "projects_insurances",
                column: "insurance_condition_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_insurances_project_id",
                table: "projects_insurances",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_suppliers_project_id",
                table: "projects_suppliers",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_suppliers_supplier_id",
                table: "projects_suppliers",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_suppliers_tax_id",
                table: "projects_suppliers",
                column: "tax_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_suppliers_attachments_project_supplier_id",
                table: "projects_suppliers_attachments",
                column: "project_supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_statement_owner_id",
                table: "statement",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_statement_project_id",
                table: "statement",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_statement_category_category_id",
                table: "statement_category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_statement_category_statement_id",
                table: "statement_category",
                column: "statement_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_payment_method_payment_method_id",
                table: "supplier_payment_method",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_payment_method_supplier_id",
                table: "supplier_payment_method",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_attachments_supplier_id",
                table: "suppliers_attachments",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_categories_category_id",
                table: "suppliers_categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_categories_supplier_id",
                table: "suppliers_categories",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_project_items_item_id",
                table: "suppliers_project_items",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_project_items_project_id",
                table: "suppliers_project_items",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_project_items_supplier_id",
                table: "suppliers_project_items",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_projects_insurances_insurance_condition_id",
                table: "suppliers_projects_insurances",
                column: "insurance_condition_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_projects_insurances_project_id",
                table: "suppliers_projects_insurances",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_projects_insurances_supplier_id",
                table: "suppliers_projects_insurances",
                column: "supplier_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_items");

            migrationBuilder.DropTable(
                name: "invoice_payment_order");

            migrationBuilder.DropTable(
                name: "owners_attachments");

            migrationBuilder.DropTable(
                name: "project_payment_method");

            migrationBuilder.DropTable(
                name: "projects_attachments");

            migrationBuilder.DropTable(
                name: "projects_insurances");

            migrationBuilder.DropTable(
                name: "projects_suppliers_attachments");

            migrationBuilder.DropTable(
                name: "statement_category");

            migrationBuilder.DropTable(
                name: "supplier_payment_method");

            migrationBuilder.DropTable(
                name: "suppliers_attachments");

            migrationBuilder.DropTable(
                name: "suppliers_categories");

            migrationBuilder.DropTable(
                name: "suppliers_project_items");

            migrationBuilder.DropTable(
                name: "suppliers_projects_insurances");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "projects_suppliers");

            migrationBuilder.DropTable(
                name: "statement");

            migrationBuilder.DropTable(
                name: "payment_method");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "insurance_condition");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "taxe");
        }
    }
}
