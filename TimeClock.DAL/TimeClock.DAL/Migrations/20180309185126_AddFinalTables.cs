using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeClock.DAL.Migrations
{
    public partial class AddFinalTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacation_AspNetUsers_EmployeeId",
                schema: "Clock",
                table: "Vacation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacation",
                schema: "Clock",
                table: "Vacation");

            migrationBuilder.RenameTable(
                name: "Vacation",
                schema: "Clock",
                newName: "Vacations");

            migrationBuilder.RenameIndex(
                name: "IX_Vacation_EmployeeId",
                schema: "Clock",
                table: "Vacations",
                newName: "IX_Vacations_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacations",
                schema: "Clock",
                table: "Vacations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                schema: "Clock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approved = table.Column<bool>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ReasonDenied = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheets_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Clock",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClockIns",
                schema: "Clock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClockInTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ClockOutTime = table.Column<DateTime>(nullable: true),
                    TimeSheetId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClockIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClockIns_TimeSheets_TimeSheetId",
                        column: x => x.TimeSheetId,
                        principalSchema: "Clock",
                        principalTable: "TimeSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClockIns_TimeSheetId",
                schema: "Clock",
                table: "ClockIns",
                column: "TimeSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_EmployeeId",
                schema: "Clock",
                table: "TimeSheets",
                column: "EmployeeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_AspNetUsers_EmployeeId",
                schema: "Clock",
                table: "Vacations");

            migrationBuilder.DropTable(
                name: "ClockIns",
                schema: "Clock");

            migrationBuilder.DropTable(
                name: "TimeSheets",
                schema: "Clock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacations",
                schema: "Clock",
                table: "Vacations");

            migrationBuilder.RenameTable(
                name: "Vacations",
                schema: "Clock",
                newName: "Vacation");

            migrationBuilder.RenameIndex(
                name: "IX_Vacations_EmployeeId",
                schema: "Clock",
                table: "Vacation",
                newName: "IX_Vacation_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacation",
                schema: "Clock",
                table: "Vacation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacation_AspNetUsers_EmployeeId",
                schema: "Clock",
                table: "Vacation",
                column: "EmployeeId",
                principalSchema: "Clock",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
