using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class AddIsConfirmedColumnToProjectEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_confirmed",
                table: "projects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_confirmed",
                table: "projects");
        }
    }
}
