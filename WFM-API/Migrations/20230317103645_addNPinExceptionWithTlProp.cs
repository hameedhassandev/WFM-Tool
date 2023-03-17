using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WFM_API.Migrations
{
    public partial class addNPinExceptionWithTlProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApprovedByPID",
                table: "Exceptions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_ApprovedByPID",
                table: "Exceptions",
                column: "ApprovedByPID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exceptions_AspNetUsers_ApprovedByPID",
                table: "Exceptions",
                column: "ApprovedByPID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
             
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exceptions_AspNetUsers_ApprovedByPID",
                table: "Exceptions");

            migrationBuilder.DropIndex(
                name: "IX_Exceptions_ApprovedByPID",
                table: "Exceptions");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedByPID",
                table: "Exceptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
