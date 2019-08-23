using Microsoft.EntityFrameworkCore.Migrations;

namespace CardiologicClinic_WebApp.Migrations
{
    public partial class appointmentCallendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VisitName",
                table: "Visit",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitName",
                table: "Visit");
        }
    }
}
