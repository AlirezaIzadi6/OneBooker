using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Users_SeedGeographyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Users",
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "ProvinceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, true, "تبریز", 1, null },
                    { 2, null, true, "ارومیه", 2, null },
                    { 3, null, true, "اردبیل", 3, null },
                    { 4, null, true, "اصفهان", 4, null },
                    { 5, null, true, "کرج", 5, null },
                    { 6, null, true, "ایلام", 6, null },
                    { 7, null, true, "بوشهر", 7, null },
                    { 8, null, true, "تهران", 8, null },
                    { 9, null, true, "شهرکرد", 9, null },
                    { 10, null, true, "بیرجند", 10, null },
                    { 11, null, true, "مشهد", 11, null },
                    { 12, null, true, "بجنورد", 12, null },
                    { 13, null, true, "اهواز", 13, null },
                    { 14, null, true, "زنجان", 14, null },
                    { 15, null, true, "سمنان", 15, null },
                    { 16, null, true, "زاهدان", 16, null },
                    { 17, null, true, "شیراز", 17, null },
                    { 18, null, true, "قزوین", 18, null },
                    { 19, null, true, "قم", 19, null },
                    { 20, null, true, "سنندج", 20, null },
                    { 21, null, true, "کرمان", 21, null },
                    { 22, null, true, "کرمانشاه", 22, null },
                    { 23, null, true, "یاسوج", 23, null },
                    { 24, null, true, "گرگان", 24, null },
                    { 25, null, true, "رشت", 25, null },
                    { 26, null, true, "خرم‌آباد", 26, null },
                    { 27, null, true, "ساری", 27, null },
                    { 28, null, true, "اراک", 28, null },
                    { 29, null, true, "بندرعباس", 29, null },
                    { 30, null, true, "همدان", 30, null },
                    { 31, null, true, "یزد", 31, null }
                });

            migrationBuilder.InsertData(
                schema: "Users",
                table: "Countries",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[] { 1, null, true, "ایران", null });

            migrationBuilder.InsertData(
                schema: "Users",
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, null, true, "آذربایجان شرقی", null },
                    { 2, 1, null, true, "آذربایجان غربی", null },
                    { 3, 1, null, true, "اردبیل", null },
                    { 4, 1, null, true, "اصفهان", null },
                    { 5, 1, null, true, "البرز", null },
                    { 6, 1, null, true, "ایلام", null },
                    { 7, 1, null, true, "بوشهر", null },
                    { 8, 1, null, true, "تهران", null },
                    { 9, 1, null, true, "چهارمحال و بختیاری", null },
                    { 10, 1, null, true, "خراسان جنوبی", null },
                    { 11, 1, null, true, "خراسان رضوی", null },
                    { 12, 1, null, true, "خراسان شمالی", null },
                    { 13, 1, null, true, "خوزستان", null },
                    { 14, 1, null, true, "زنجان", null },
                    { 15, 1, null, true, "سمنان", null },
                    { 16, 1, null, true, "سیستان و بلوچستان", null },
                    { 17, 1, null, true, "فارس", null },
                    { 18, 1, null, true, "قزوین", null },
                    { 19, 1, null, true, "قم", null },
                    { 20, 1, null, true, "کردستان", null },
                    { 21, 1, null, true, "کرمان", null },
                    { 22, 1, null, true, "کرمانشاه", null },
                    { 23, 1, null, true, "کهگیلویه و بویراحمد", null },
                    { 24, 1, null, true, "گلستان", null },
                    { 25, 1, null, true, "گیلان", null },
                    { 26, 1, null, true, "لرستان", null },
                    { 27, 1, null, true, "مازندران", null },
                    { 28, 1, null, true, "مرکزی", null },
                    { 29, 1, null, true, "هرمزگان", null },
                    { 30, 1, null, true, "همدان", null },
                    { 31, 1, null, true, "یزد", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Cities",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 31);
        }
    }
}
