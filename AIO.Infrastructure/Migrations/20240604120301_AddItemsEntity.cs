using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class AddItemsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "suppliers_project_items");

            migrationBuilder.AddColumn<int>(
                name: "item_id",
                table: "suppliers_project_items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_project_items_item_id",
                table: "suppliers_project_items",
                column: "item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_project_items_items_item_id",
                table: "suppliers_project_items",
                column: "item_id",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_project_items_items_item_id",
                table: "suppliers_project_items");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_project_items_item_id",
                table: "suppliers_project_items");

            migrationBuilder.DropColumn(
                name: "item_id",
                table: "suppliers_project_items");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "suppliers_project_items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
