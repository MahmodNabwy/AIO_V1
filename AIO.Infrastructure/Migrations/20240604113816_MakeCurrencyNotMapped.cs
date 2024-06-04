using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class MakeCurrencyNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currency",
                table: "suppliers_projects_payment_methods");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "projects_insurances");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "project_payment_method");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "currency",
                table: "suppliers_projects_payment_methods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "currency",
                table: "suppliers_projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "currency",
                table: "projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "currency",
                table: "project_payment_method",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
