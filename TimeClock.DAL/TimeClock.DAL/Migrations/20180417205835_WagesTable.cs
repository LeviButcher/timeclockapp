using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeClock.DAL.Migrations
{
    public partial class WagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyWage",
                schema: "Clock",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Wages",
                schema: "Clock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<string>(nullable: false),
                    HourlyWage = table.Column<float>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wages_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Clock",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wages_EmployeeId",
                schema: "Clock",
                table: "Wages",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wages",
                schema: "Clock");

            migrationBuilder.AddColumn<float>(
                name: "HourlyWage",
                schema: "Clock",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
