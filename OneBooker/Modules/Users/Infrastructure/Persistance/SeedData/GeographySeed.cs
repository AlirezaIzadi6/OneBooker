using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Domain.Addresses.Entities;

namespace OneBooker.Modules.Users.Infrastructure.Persistance.SeedData;

public static class GeographySeed
{
    public static void SeedGeography(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = "ایران", IsActive = true }
        );

        modelBuilder.Entity<Province>().HasData(
            new Province { Id = 1, CountryId = 1, Name = "آذربایجان شرقی", IsActive = true },
            new Province { Id = 2, CountryId = 1, Name = "آذربایجان غربی", IsActive = true },
            new Province { Id = 3, CountryId = 1, Name = "اردبیل", IsActive = true },
            new Province { Id = 4, CountryId = 1, Name = "اصفهان", IsActive = true },
            new Province { Id = 5, CountryId = 1, Name = "البرز", IsActive = true },
            new Province { Id = 6, CountryId = 1, Name = "ایلام", IsActive = true },
            new Province { Id = 7, CountryId = 1, Name = "بوشهر", IsActive = true },
            new Province { Id = 8, CountryId = 1, Name = "تهران", IsActive = true },
            new Province { Id = 9, CountryId = 1, Name = "چهارمحال و بختیاری", IsActive = true },
            new Province { Id = 10, CountryId = 1, Name = "خراسان جنوبی", IsActive = true },
            new Province { Id = 11, CountryId = 1, Name = "خراسان رضوی", IsActive = true },
            new Province { Id = 12, CountryId = 1, Name = "خراسان شمالی", IsActive = true },
            new Province { Id = 13, CountryId = 1, Name = "خوزستان", IsActive = true },
            new Province { Id = 14, CountryId = 1, Name = "زنجان", IsActive = true },
            new Province { Id = 15, CountryId = 1, Name = "سمنان", IsActive = true },
            new Province { Id = 16, CountryId = 1, Name = "سیستان و بلوچستان", IsActive = true },
            new Province { Id = 17, CountryId = 1, Name = "فارس", IsActive = true },
            new Province { Id = 18, CountryId = 1, Name = "قزوین", IsActive = true },
            new Province { Id = 19, CountryId = 1, Name = "قم", IsActive = true },
            new Province { Id = 20, CountryId = 1, Name = "کردستان", IsActive = true },
            new Province { Id = 21, CountryId = 1, Name = "کرمان", IsActive = true },
            new Province { Id = 22, CountryId = 1, Name = "کرمانشاه", IsActive = true },
            new Province { Id = 23, CountryId = 1, Name = "کهگیلویه و بویراحمد", IsActive = true },
            new Province { Id = 24, CountryId = 1, Name = "گلستان", IsActive = true },
            new Province { Id = 25, CountryId = 1, Name = "گیلان", IsActive = true },
            new Province { Id = 26, CountryId = 1, Name = "لرستان", IsActive = true },
            new Province { Id = 27, CountryId = 1, Name = "مازندران", IsActive = true },
            new Province { Id = 28, CountryId = 1, Name = "مرکزی", IsActive = true },
            new Province { Id = 29, CountryId = 1, Name = "هرمزگان", IsActive = true },
            new Province { Id = 30, CountryId = 1, Name = "همدان", IsActive = true },
            new Province { Id = 31, CountryId = 1, Name = "یزد", IsActive = true }
        );

        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, ProvinceId = 1, Name = "تبریز", IsActive = true },
            new City { Id = 2, ProvinceId = 2, Name = "ارومیه", IsActive = true },
            new City { Id = 3, ProvinceId = 3, Name = "اردبیل", IsActive = true },
            new City { Id = 4, ProvinceId = 4, Name = "اصفهان", IsActive = true },
            new City { Id = 5, ProvinceId = 5, Name = "کرج", IsActive = true },
            new City { Id = 6, ProvinceId = 6, Name = "ایلام", IsActive = true },
            new City { Id = 7, ProvinceId = 7, Name = "بوشهر", IsActive = true },
            new City { Id = 8, ProvinceId = 8, Name = "تهران", IsActive = true },
            new City { Id = 9, ProvinceId = 9, Name = "شهرکرد", IsActive = true },
            new City { Id = 10, ProvinceId = 10, Name = "بیرجند", IsActive = true },
            new City { Id = 11, ProvinceId = 11, Name = "مشهد", IsActive = true },
            new City { Id = 12, ProvinceId = 12, Name = "بجنورد", IsActive = true },
            new City { Id = 13, ProvinceId = 13, Name = "اهواز", IsActive = true },
            new City { Id = 14, ProvinceId = 14, Name = "زنجان", IsActive = true },
            new City { Id = 15, ProvinceId = 15, Name = "سمنان", IsActive = true },
            new City { Id = 16, ProvinceId = 16, Name = "زاهدان", IsActive = true },
            new City { Id = 17, ProvinceId = 17, Name = "شیراز", IsActive = true },
            new City { Id = 18, ProvinceId = 18, Name = "قزوین", IsActive = true },
            new City { Id = 19, ProvinceId = 19, Name = "قم", IsActive = true },
            new City { Id = 20, ProvinceId = 20, Name = "سنندج", IsActive = true },
            new City { Id = 21, ProvinceId = 21, Name = "کرمان", IsActive = true },
            new City { Id = 22, ProvinceId = 22, Name = "کرمانشاه", IsActive = true },
            new City { Id = 23, ProvinceId = 23, Name = "یاسوج", IsActive = true },
            new City { Id = 24, ProvinceId = 24, Name = "گرگان", IsActive = true },
            new City { Id = 25, ProvinceId = 25, Name = "رشت", IsActive = true },
            new City { Id = 26, ProvinceId = 26, Name = "خرم‌آباد", IsActive = true },
            new City { Id = 27, ProvinceId = 27, Name = "ساری", IsActive = true },
            new City { Id = 28, ProvinceId = 28, Name = "اراک", IsActive = true },
            new City { Id = 29, ProvinceId = 29, Name = "بندرعباس", IsActive = true },
            new City { Id = 30, ProvinceId = 30, Name = "همدان", IsActive = true },
            new City { Id = 31, ProvinceId = 31, Name = "یزد", IsActive = true }
        );
    }
}