using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tallinnarakenduskolledz.Migrations
{
    /// <inheritdoc />
    public partial class õpetaja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Instructor",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "AmountOfCars",
                table: "Instructor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfClass",
                table: "Instructor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "homes",
                table: "Instructor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfCars",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "TypeOfClass",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "homes",
                table: "Instructor");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Instructor",
                newName: "Name");
        }
    }
}
