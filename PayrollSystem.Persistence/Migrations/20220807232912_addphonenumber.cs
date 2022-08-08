using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollSystem.Persistence.Migrations
{
    public partial class addphonenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desination",
                table: "Employees",
                newName: "Designation");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "Employees",
                newName: "Desination");
        }
    }
}
