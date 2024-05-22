using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class RemovePaymentMethodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_project_payment_method_payment_method_payment_method_id",
                table: "project_payment_method");

            migrationBuilder.DropForeignKey(
                name: "FK_supplier_payment_method_payment_method_payment_method_id",
                table: "supplier_payment_method");

            migrationBuilder.DropTable(
                name: "payment_method");

            migrationBuilder.DropIndex(
                name: "IX_supplier_payment_method_payment_method_id",
                table: "supplier_payment_method");

            migrationBuilder.DropIndex(
                name: "IX_project_payment_method_payment_method_id",
                table: "project_payment_method");

            migrationBuilder.RenameColumn(
                name: "payment_method_id",
                table: "supplier_payment_method",
                newName: "type_id ");

            migrationBuilder.RenameColumn(
                name: "payment_method_id",
                table: "project_payment_method",
                newName: "type_id ");

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "supplier_payment_method",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "amount_concurrency ",
                table: "supplier_payment_method",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "percentage",
                table: "supplier_payment_method",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "project_id",
                table: "supplier_payment_method",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "project_payment_method",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "amount_concurrency ",
                table: "project_payment_method",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "percentage",
                table: "project_payment_method",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_supplier_payment_method_project_id",
                table: "supplier_payment_method",
                column: "project_id");

            migrationBuilder.AddForeignKey(
                name: "FK_supplier_payment_method_projects_project_id",
                table: "supplier_payment_method",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplier_payment_method_projects_project_id",
                table: "supplier_payment_method");

            migrationBuilder.DropIndex(
                name: "IX_supplier_payment_method_project_id",
                table: "supplier_payment_method");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "supplier_payment_method");

            migrationBuilder.DropColumn(
                name: "amount_concurrency ",
                table: "supplier_payment_method");

            migrationBuilder.DropColumn(
                name: "percentage",
                table: "supplier_payment_method");

            migrationBuilder.DropColumn(
                name: "project_id",
                table: "supplier_payment_method");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "project_payment_method");

            migrationBuilder.DropColumn(
                name: "amount_concurrency ",
                table: "project_payment_method");

            migrationBuilder.DropColumn(
                name: "percentage",
                table: "project_payment_method");

            migrationBuilder.RenameColumn(
                name: "type_id ",
                table: "supplier_payment_method",
                newName: "payment_method_id");

            migrationBuilder.RenameColumn(
                name: "type_id ",
                table: "project_payment_method",
                newName: "payment_method_id");

            migrationBuilder.CreateTable(
                name: "payment_method",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_payment_method", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_supplier_payment_method_payment_method_id",
                table: "supplier_payment_method",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_payment_method_payment_method_id",
                table: "project_payment_method",
                column: "payment_method_id");

            migrationBuilder.AddForeignKey(
                name: "FK_project_payment_method_payment_method_payment_method_id",
                table: "project_payment_method",
                column: "payment_method_id",
                principalTable: "payment_method",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_supplier_payment_method_payment_method_payment_method_id",
                table: "supplier_payment_method",
                column: "payment_method_id",
                principalTable: "payment_method",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
