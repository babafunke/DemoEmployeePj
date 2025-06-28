using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEmployeePj.Migrations
{
    /// <inheritdoc />
    public partial class addedsimplifiednametotheemployeemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SimplifiedName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SimplifiedName",
                table: "Employees");
        }
    }
}
