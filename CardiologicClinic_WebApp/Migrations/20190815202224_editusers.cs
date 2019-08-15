using Microsoft.EntityFrameworkCore.Migrations;

namespace CardiologicClinic_WebApp.Migrations
{
    public partial class editusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "UserName");
        }
    }
}
