using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class NullableTaxIdForProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_taxe_tax_id",
                table: "projects");

            migrationBuilder.AlterColumn<int>(
                name: "tax_id",
                table: "projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_taxe_tax_id",
                table: "projects",
                column: "tax_id",
                principalTable: "taxe",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_taxe_tax_id",
                table: "projects");

            migrationBuilder.AlterColumn<int>(
                name: "tax_id",
                table: "projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_taxe_tax_id",
                table: "projects",
                column: "tax_id",
                principalTable: "taxe",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
