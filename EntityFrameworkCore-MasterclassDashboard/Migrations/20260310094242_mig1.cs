using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore_MasterclassDashboard.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Activities",
                newName: "ActivityType");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Activities",
                newName: "ActivityTitle");

            migrationBuilder.AddColumn<string>(
                name: "ActivityDescription",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityDescription",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "ActivityType",
                table: "Activities",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ActivityTitle",
                table: "Activities",
                newName: "Description");
        }
    }
}
