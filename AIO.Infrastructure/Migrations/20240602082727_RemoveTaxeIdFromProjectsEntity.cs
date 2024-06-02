using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class RemoveTaxeIdFromProjectsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_taxe_tax_id",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_projects_tax_id",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "tax_id",
                table: "projects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tax_id",
                table: "projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_projects_tax_id",
                table: "projects",
                column: "tax_id");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_taxe_tax_id",
                table: "projects",
                column: "tax_id",
                principalTable: "taxe",
                principalColumn: "id");
        }
    }
}
