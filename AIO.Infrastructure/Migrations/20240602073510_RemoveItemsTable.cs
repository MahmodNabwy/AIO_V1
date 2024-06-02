using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class RemoveItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_project_items_items_item_id",
                table: "suppliers_project_items");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_project_items_item_id",
                table: "suppliers_project_items");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "suppliers_project_items",
                newName: "amount");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "suppliers_project_items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "item_total_price",
                table: "suppliers_project_items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "unit_price",
                table: "suppliers_project_items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "suppliers_project_items");

            migrationBuilder.DropColumn(
                name: "item_total_price",
                table: "suppliers_project_items");

            migrationBuilder.DropColumn(
                name: "unit_price",
                table: "suppliers_project_items");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "suppliers_project_items",
                newName: "item_id");

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
