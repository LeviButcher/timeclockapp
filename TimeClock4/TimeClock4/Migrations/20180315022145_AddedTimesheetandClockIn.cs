using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeClock4.Migrations
{
    public partial class AddedTimesheetandClockIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ExemptFromOvertime",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approved = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ExemptFromOvertime = table.Column<bool>(nullable: false),
                    ReasonDenied = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClockIns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClockInTime = table.Column<DateTime>(nullable: false),
                    ClockOutTime = table.Column<DateTime>(nullable: true),
                    TimeSheetId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClockIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClockIns_TimeSheets_TimeSheetId",
                        column: x => x.TimeSheetId,
                        principalTable: "TimeSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClockIns_TimeSheetId",
                table: "ClockIns",
                column: "TimeSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_UserId",
                table: "TimeSheets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClockIns");

            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "ExemptFromOvertime",
                table: "AspNetUsers");
        }
    }
}
