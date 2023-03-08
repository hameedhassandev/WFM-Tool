using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WFM_API.Migrations
{
    public partial class rolbackNPofAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exceptions_EmployeeAppointments_EmployeeAppointmentId",
                table: "Exceptions");

            migrationBuilder.DropIndex(
                name: "IX_Exceptions_EmployeeAppointmentId",
                table: "Exceptions");

            migrationBuilder.DropColumn(
                name: "EmployeeAppointmentId",
                table: "Exceptions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeAppointmentId",
                table: "Exceptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_EmployeeAppointmentId",
                table: "Exceptions",
                column: "EmployeeAppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exceptions_EmployeeAppointments_EmployeeAppointmentId",
                table: "Exceptions",
                column: "EmployeeAppointmentId",
                principalTable: "EmployeeAppointments",
                principalColumn: "Id");
        }
    }
}
