using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class MakeCurrencyGlobalOnProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "insurance_letter_concurrency_type ",
                table: "projects_insurances");

            migrationBuilder.RenameColumn(
                name: "amount_concurrency ",
                table: "suppliers_projects_payment_methods",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "type_id ",
                table: "suppliers_projects_insurances",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "amount_concurrency_type ",
                table: "suppliers_projects_insurances",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "total_price_concurrency",
                table: "projects_suppliers",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "amount_concurrency_type ",
                table: "projects_insurances",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "total_price_concurrency",
                table: "projects",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "amount_concurrency ",
                table: "project_payment_method",
                newName: "currency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "currency",
                table: "suppliers_projects_payment_methods",
                newName: "amount_concurrency ");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "suppliers_projects_insurances",
                newName: "type_id ");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "suppliers_projects_insurances",
                newName: "amount_concurrency_type ");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "projects_suppliers",
                newName: "total_price_concurrency");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "projects_insurances",
                newName: "amount_concurrency_type ");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "projects",
                newName: "total_price_concurrency");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "project_payment_method",
                newName: "amount_concurrency ");

            migrationBuilder.AddColumn<int>(
                name: "insurance_letter_concurrency_type ",
                table: "projects_insurances",
                type: "int",
                nullable: true);
        }
    }
}
