using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Context.Migrations
{
    /// <inheritdoc />
    public partial class TypeRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Room",
                newName: "TypeRoom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeRoom",
                table: "Room",
                newName: "Type");
        }
    }
}
