using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructures.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Culture>().HasData(
                new Culture(new CultureInfo("fa-IR"))
                {
                    Id = 1,
                    IsActive = true,
                    IsSystem = true,
                    DisplayName = "فارسی",
                },
                new Culture(new CultureInfo("en-US"))
                {
                    Id = 2,
                    IsActive = true,
                    IsSystem = true,
                    DisplayName = "English",
                }
            );
        }
    }
}
