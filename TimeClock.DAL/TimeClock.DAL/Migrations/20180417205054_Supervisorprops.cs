using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeClock.DAL.Migrations
{
    public partial class Supervisorprops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                schema: "Clock",
                table: "Vacations",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                schema: "Clock",
                table: "TimeSheets",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                schema: "Clock",
                table: "ClockIns",
                newName: "TimeStamp");

            migrationBuilder.AddColumn<string>(
                name: "SupervisorId",
                schema: "Clock",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SupervisorId",
                schema: "Clock",
                table: "AspNetUsers",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_SupervisorId",
                schema: "Clock",
                table: "AspNetUsers",
                column: "SupervisorId",
                principalSchema: "Clock",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_SupervisorId",
                schema: "Clock",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SupervisorId",
                schema: "Clock",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                schema: "Clock",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                schema: "Clock",
                table: "Vacations",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                schema: "Clock",
                table: "TimeSheets",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                schema: "Clock",
                table: "ClockIns",
                newName: "Timestamp");
        }
    }
}
