using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Users_ChangeUserAndCustomerStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                schema: "Users",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Users",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                schema: "Users",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Users",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                schema: "Users",
                table: "Customers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Users",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Users",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Users",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                schema: "Users",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Users",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Users",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                schema: "Users",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
