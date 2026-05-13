using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Users_AddUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                schema: "Users",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                schema: "Users",
                table: "Users");
        }
    }
}
