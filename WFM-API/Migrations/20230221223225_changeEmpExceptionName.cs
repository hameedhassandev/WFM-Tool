using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WFM_API.Migrations
{
    public partial class changeEmpExceptionName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExceptionComment_Exceptions_ExceptionId",
                table: "ExceptionComment");

            migrationBuilder.RenameColumn(
                name: "ExceptionId",
                table: "ExceptionComment",
                newName: "EmpExceptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ExceptionComment_ExceptionId",
                table: "ExceptionComment",
                newName: "IX_ExceptionComment_EmpExceptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExceptionComment_Exceptions_EmpExceptionId",
                table: "ExceptionComment",
                column: "EmpExceptionId",
                principalTable: "Exceptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExceptionComment_Exceptions_EmpExceptionId",
                table: "ExceptionComment");

            migrationBuilder.RenameColumn(
                name: "EmpExceptionId",
                table: "ExceptionComment",
                newName: "ExceptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ExceptionComment_EmpExceptionId",
                table: "ExceptionComment",
                newName: "IX_ExceptionComment_ExceptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExceptionComment_Exceptions_ExceptionId",
                table: "ExceptionComment",
                column: "ExceptionId",
                principalTable: "Exceptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
