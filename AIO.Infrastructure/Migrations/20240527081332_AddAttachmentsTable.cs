using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class AddAttachmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "size",
                table: "suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "uid",
                table: "suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "url",
                table: "suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "name",
                table: "projects_suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "size",
                table: "projects_suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "uid",
                table: "projects_suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "url",
                table: "projects_suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "name",
                table: "projects_attachments");

            migrationBuilder.DropColumn(
                name: "size",
                table: "projects_attachments");

            migrationBuilder.DropColumn(
                name: "uid",
                table: "projects_attachments");

            migrationBuilder.DropColumn(
                name: "url",
                table: "projects_attachments");

            migrationBuilder.DropColumn(
                name: "name",
                table: "owners_attachments");

            migrationBuilder.DropColumn(
                name: "size",
                table: "owners_attachments");

            migrationBuilder.DropColumn(
                name: "uid",
                table: "owners_attachments");

            migrationBuilder.DropColumn(
                name: "url",
                table: "owners_attachments");

            migrationBuilder.RenameColumn(
                name: "media_type",
                table: "suppliers_attachments",
                newName: "attachment_id");

            migrationBuilder.RenameColumn(
                name: "media_type",
                table: "projects_suppliers_attachments",
                newName: "attachment_id");

            migrationBuilder.RenameColumn(
                name: "media_type",
                table: "projects_attachments",
                newName: "attachment_id");

            migrationBuilder.RenameColumn(
                name: "media_type",
                table: "owners_attachments",
                newName: "attachment_id");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "suppliers_attachments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "projects_suppliers_attachments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "projects_attachments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "owners_attachments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "attachments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    uid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    media_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachments", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_attachments_attachment_id",
                table: "suppliers_attachments",
                column: "attachment_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_suppliers_attachments_attachment_id",
                table: "projects_suppliers_attachments",
                column: "attachment_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_attachments_attachment_id",
                table: "projects_attachments",
                column: "attachment_id");

            migrationBuilder.CreateIndex(
                name: "IX_owners_attachments_attachment_id",
                table: "owners_attachments",
                column: "attachment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_owners_attachments_attachments_attachment_id",
                table: "owners_attachments",
                column: "attachment_id",
                principalTable: "attachments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_attachments_attachments_attachment_id",
                table: "projects_attachments",
                column: "attachment_id",
                principalTable: "attachments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_suppliers_attachments_attachments_attachment_id",
                table: "projects_suppliers_attachments",
                column: "attachment_id",
                principalTable: "attachments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_attachments_attachments_attachment_id",
                table: "suppliers_attachments",
                column: "attachment_id",
                principalTable: "attachments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_owners_attachments_attachments_attachment_id",
                table: "owners_attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_attachments_attachments_attachment_id",
                table: "projects_attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_suppliers_attachments_attachments_attachment_id",
                table: "projects_suppliers_attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_attachments_attachments_attachment_id",
                table: "suppliers_attachments");

            migrationBuilder.DropTable(
                name: "attachments");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_attachments_attachment_id",
                table: "suppliers_attachments");

            migrationBuilder.DropIndex(
                name: "IX_projects_suppliers_attachments_attachment_id",
                table: "projects_suppliers_attachments");

            migrationBuilder.DropIndex(
                name: "IX_projects_attachments_attachment_id",
                table: "projects_attachments");

            migrationBuilder.DropIndex(
                name: "IX_owners_attachments_attachment_id",
                table: "owners_attachments");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "projects_suppliers_attachments");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "projects_attachments");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "owners_attachments");

            migrationBuilder.RenameColumn(
                name: "attachment_id",
                table: "suppliers_attachments",
                newName: "media_type");

            migrationBuilder.RenameColumn(
                name: "attachment_id",
                table: "projects_suppliers_attachments",
                newName: "media_type");

            migrationBuilder.RenameColumn(
                name: "attachment_id",
                table: "projects_attachments",
                newName: "media_type");

            migrationBuilder.RenameColumn(
                name: "attachment_id",
                table: "owners_attachments",
                newName: "media_type");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "suppliers_attachments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "suppliers_attachments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "uid",
                table: "suppliers_attachments",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "suppliers_attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "projects_suppliers_attachments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "projects_suppliers_attachments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "uid",
                table: "projects_suppliers_attachments",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "projects_suppliers_attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "projects_attachments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "projects_attachments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "uid",
                table: "projects_attachments",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "projects_attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "owners_attachments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "owners_attachments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "uid",
                table: "owners_attachments",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "owners_attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
