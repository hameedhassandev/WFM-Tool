using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WFM_API.Migrations
{
    public partial class addAppointmentAndExceptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PID",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ExceptionStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExceptionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfDay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExceptionTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatorPID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprovedByPID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<TimeSpan>(type: "time", nullable: false),
                    To = table.Column<TimeSpan>(type: "time", nullable: false),
                    ExceptionStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exceptions_AspNetUsers_CreatorPID",
                        column: x => x.CreatorPID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exceptions_ExceptionStatus_ExceptionStatusId",
                        column: x => x.ExceptionStatusId,
                        principalTable: "ExceptionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exceptions_ExceptionType_ExceptionTypeId",
                        column: x => x.ExceptionTypeId,
                        principalTable: "ExceptionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    EmployeePID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeOfDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAppointments_AspNetUsers_EmployeePID",
                        column: x => x.EmployeePID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAppointments_TypeOfDay_TypeOfDayId",
                        column: x => x.TypeOfDayId,
                        principalTable: "TypeOfDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorPID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExceptionComment_Exceptions_ExceptionId",
                        column: x => x.ExceptionId,
                        principalTable: "Exceptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Break",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeAppointmentId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<TimeSpan>(type: "time", nullable: false),
                    To = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Break", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Break_EmployeeAppointments_EmployeeAppointmentId",
                        column: x => x.EmployeeAppointmentId,
                        principalTable: "EmployeeAppointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Break_EmployeeAppointmentId",
                table: "Break",
                column: "EmployeeAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAppointments_EmployeePID",
                table: "EmployeeAppointments",
                column: "EmployeePID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAppointments_TypeOfDayId",
                table: "EmployeeAppointments",
                column: "TypeOfDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionComment_ExceptionId",
                table: "ExceptionComment",
                column: "ExceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_CreatorPID",
                table: "Exceptions",
                column: "CreatorPID");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_ExceptionStatusId",
                table: "Exceptions",
                column: "ExceptionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_ExceptionTypeId",
                table: "Exceptions",
                column: "ExceptionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Break");

            migrationBuilder.DropTable(
                name: "ExceptionComment");

            migrationBuilder.DropTable(
                name: "EmployeeAppointments");

            migrationBuilder.DropTable(
                name: "Exceptions");

            migrationBuilder.DropTable(
                name: "TypeOfDay");

            migrationBuilder.DropTable(
                name: "ExceptionStatus");

            migrationBuilder.DropTable(
                name: "ExceptionType");

            migrationBuilder.AddColumn<int>(
                name: "PID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
