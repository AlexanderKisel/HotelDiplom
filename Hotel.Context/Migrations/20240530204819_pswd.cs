using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Context.Migrations
{
    /// <inheritdoc />
    public partial class pswd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Worker_Password",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Person_Password",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Worker",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Worker",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Person",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_Password",
                table: "Worker",
                column: "Password",
                unique: true,
                filter: "DeletedAt is null");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Password",
                table: "Person",
                column: "Password",
                unique: true,
                filter: "DeletedAt is null");
        }
    }
}
