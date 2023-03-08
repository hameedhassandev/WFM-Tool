using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WFM_API.Migrations
{
    public partial class testFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exceptions_EmployeeAppointments_EmployeeAppointmentId",
                table: "Exceptions");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeAppointmentId",
                table: "Exceptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_Exceptions_EmployeeAppointments_EmployeeAppointmentId",
                table: "Exceptions",
                column: "EmployeeAppointmentId",
                principalTable: "EmployeeAppointments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exceptions_EmployeeAppointments_EmployeeAppointmentId",
                table: "Exceptions");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeAppointmentId",
                table: "Exceptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Exceptions_EmployeeAppointments_EmployeeAppointmentId",
                table: "Exceptions",
                column: "EmployeeAppointmentId",
                principalTable: "EmployeeAppointments",
                principalColumn: "Id");
        }
    }
}
