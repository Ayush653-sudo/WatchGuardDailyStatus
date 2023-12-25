using Microsoft.EntityFrameworkCore.Migrations;

namespace Tooth_Booth_API.Migrations
{
    public partial class initialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClinicName",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Appointments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "ClinicName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
