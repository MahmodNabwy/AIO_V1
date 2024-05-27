using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIO.Infrastructure.Migrations
{
    public partial class RemoveInsuranceConditionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_insurances_insurance_condition_insurance_condition_id",
                table: "projects_insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_projects_insurances_insurance_condition_insurance_condition_id",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropTable(
                name: "insurance_condition");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_projects_insurances_insurance_condition_id",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropIndex(
                name: "IX_projects_insurances_insurance_condition_id",
                table: "projects_insurances");

            migrationBuilder.RenameColumn(
                name: "insurance_condition_id",
                table: "suppliers_projects_insurances",
                newName: "type_id ");

            migrationBuilder.RenameColumn(
                name: "insurance_condition_id",
                table: "projects_insurances",
                newName: "type_id ");

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "suppliers_projects_insurances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "amount_concurrency_type ",
                table: "suppliers_projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "suppliers_projects_insurances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "percentage",
                table: "suppliers_projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "period",
                table: "suppliers_projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status_id ",
                table: "suppliers_projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "projects_insurances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "amount_concurrency_type ",
                table: "projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "projects_insurances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "percentage",
                table: "projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "period",
                table: "projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status_id ",
                table: "projects_insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "amount_concurrency_type ",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "date",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "percentage",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "period",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "status_id ",
                table: "suppliers_projects_insurances");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "projects_insurances");

            migrationBuilder.DropColumn(
                name: "amount_concurrency_type ",
                table: "projects_insurances");

            migrationBuilder.DropColumn(
                name: "date",
                table: "projects_insurances");

            migrationBuilder.DropColumn(
                name: "percentage",
                table: "projects_insurances");

            migrationBuilder.DropColumn(
                name: "period",
                table: "projects_insurances");

            migrationBuilder.DropColumn(
                name: "status_id ",
                table: "projects_insurances");

            migrationBuilder.RenameColumn(
                name: "type_id ",
                table: "suppliers_projects_insurances",
                newName: "insurance_condition_id");

            migrationBuilder.RenameColumn(
                name: "type_id ",
                table: "projects_insurances",
                newName: "insurance_condition_id");

            migrationBuilder.CreateTable(
                name: "insurance_condition",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    amount_concurrency_type = table.Column<int>(name: "amount_concurrency_type ", type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    percentage = table.Column<int>(type: "int", nullable: false),
                    period = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(name: "status_id ", type: "int", nullable: false),
                    type_id = table.Column<int>(name: "type_id ", type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_condition", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_projects_insurances_insurance_condition_id",
                table: "suppliers_projects_insurances",
                column: "insurance_condition_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_insurances_insurance_condition_id",
                table: "projects_insurances",
                column: "insurance_condition_id");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_insurances_insurance_condition_insurance_condition_id",
                table: "projects_insurances",
                column: "insurance_condition_id",
                principalTable: "insurance_condition",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_projects_insurances_insurance_condition_insurance_condition_id",
                table: "suppliers_projects_insurances",
                column: "insurance_condition_id",
                principalTable: "insurance_condition",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
