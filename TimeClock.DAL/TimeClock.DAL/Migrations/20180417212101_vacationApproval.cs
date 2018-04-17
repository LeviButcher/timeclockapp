using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeClock.DAL.Migrations
{
    public partial class vacationApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_AspNetUsers_EmployeeId",
                schema: "Clock",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "Approved",
                schema: "Clock",
                table: "Vacations");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                schema: "Clock",
                table: "Vacations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalId",
                schema: "Clock",
                table: "Vacations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_ApprovalId",
                schema: "Clock",
                table: "Vacations",
                column: "ApprovalId",
                unique: true,
                filter: "[ApprovalId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Approvals_ApprovalId",
                schema: "Clock",
                table: "Vacations",
                column: "ApprovalId",
                principalSchema: "Clock",
                principalTable: "Approvals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_AspNetUsers_EmployeeId",
                schema: "Clock",
                table: "Vacations",
                column: "EmployeeId",
                principalSchema: "Clock",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Approvals_ApprovalId",
                schema: "Clock",
                table: "Vacations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_AspNetUsers_EmployeeId",
                schema: "Clock",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_ApprovalId",
                schema: "Clock",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "ApprovalId",
                schema: "Clock",
                table: "Vacations");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                schema: "Clock",
                table: "Vacations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                schema: "Clock",
                table: "Vacations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_AspNetUsers_EmployeeId",
                schema: "Clock",
                table: "Vacations",
                column: "EmployeeId",
                principalSchema: "Clock",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
