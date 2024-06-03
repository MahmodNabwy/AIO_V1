using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class AddIsReturnedFlagToInsuranceEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_returned",
                table: "suppliers_projects_insurances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_returned",
                table: "projects_insurances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "include_taxes",
                table: "projects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_returned",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "is_returned",
                table: "projects_insurances");

            migrationBuilder.DropColumn(
                name: "include_taxes",
                table: "projects");
        }
    }
}
