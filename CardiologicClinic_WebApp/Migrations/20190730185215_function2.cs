using Microsoft.EntityFrameworkCore.Migrations;

namespace CardiologicClinic_WebApp.Migrations
{
    public partial class function2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Function",
                table: "AspNetUsers",
                newName: "UserRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "AspNetUsers",
                newName: "Function");
        }
    }
}
