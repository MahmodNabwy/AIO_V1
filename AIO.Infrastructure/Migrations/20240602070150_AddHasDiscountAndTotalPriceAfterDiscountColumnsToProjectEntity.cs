using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class AddHasDiscountAndTotalPriceAfterDiscountColumnsToProjectEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "has_discount",
                table: "projects",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "total_price_after_discount",
                table: "projects",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "has_discount",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "total_price_after_discount",
                table: "projects");
        }
    }
}
