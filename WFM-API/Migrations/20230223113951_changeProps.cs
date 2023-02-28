using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WFM_API.Migrations
{
    public partial class changeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "EmployeeAppointments");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExceptionDate",
                table: "Exceptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "EmployeeAppointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "EmployeeAppointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExceptionDate",
                table: "Exceptions");

            migrationBuilder.DropColumn(
                name: "From",
                table: "EmployeeAppointments");

            migrationBuilder.DropColumn(
                name: "To",
                table: "EmployeeAppointments");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "EmployeeAppointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
