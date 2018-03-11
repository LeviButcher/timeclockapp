using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeClock2.Data.Migrations
{
    public partial class EmployeeHaveVacation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Vacations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Vacations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_UserId",
                table: "Vacations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_AspNetUsers_UserId",
                table: "Vacations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_AspNetUsers_UserId",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_UserId",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vacations");
        }
    }
}
