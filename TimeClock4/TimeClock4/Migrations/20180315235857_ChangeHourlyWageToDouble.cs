using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeClock4.Migrations
{
    public partial class ChangeHourlyWageToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "HourlyWage",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "HourlyWage",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
