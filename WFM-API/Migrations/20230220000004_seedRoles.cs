using Microsoft.EntityFrameworkCore.Migrations;
using WFM_API.Helpers;

#nullable disable

namespace WFM_API.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            values: new object[] { Guid.NewGuid().ToString(), Roles.EmployeeRole, Roles.EmployeeRole.ToUpper(), Guid.NewGuid().ToString() }
            );
            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            values: new object[] { Guid.NewGuid().ToString(), Roles.TeamLeaderRole, Roles.TeamLeaderRole.ToUpper(), Guid.NewGuid().ToString() }
            );
            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            values: new object[] { Guid.NewGuid().ToString(), Roles.WfmManager, Roles.WfmManager.ToUpper(), Guid.NewGuid().ToString() }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles]");

        }
    }
}
