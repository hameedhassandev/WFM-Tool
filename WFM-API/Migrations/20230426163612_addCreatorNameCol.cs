using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WFM_API.Migrations
{
    public partial class addCreatorNameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorName",
                table: "ExceptionComment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorName",
                table: "ExceptionComment");
        }
    }
}
