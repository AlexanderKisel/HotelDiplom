using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Context.Migrations
{
    /// <inheritdoc />
    public partial class EnumType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeRooms",
                table: "Room",
                newName: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Room",
                newName: "TypeRooms");
        }
    }
}
