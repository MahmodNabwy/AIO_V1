using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class AddInsuranceLetterValueColumnToProjectInsuranceAndSupplierProjectInsurances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "insurance_letter_concurrency_type ",
                table: "suppliers_projects_insurances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "insurance_letter_value",
                table: "suppliers_projects_insurances",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_discount",
                table: "projects_suppliers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "total_price_after_discount",
                table: "projects_suppliers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "insurance_letter_concurrency_type ",
                table: "projects_insurances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "insurance_letter_value",
                table: "projects_insurances",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "insurance_letter_concurrency_type ",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "insurance_letter_value",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "has_discount",
                table: "projects_suppliers");

            migrationBuilder.DropColumn(
                name: "total_price_after_discount",
                table: "projects_suppliers");

            migrationBuilder.DropColumn(
                name: "insurance_letter_concurrency_type ",
                table: "projects_insurances");

            migrationBuilder.DropColumn(
                name: "insurance_letter_value",
                table: "projects_insurances");
        }
    }
}
