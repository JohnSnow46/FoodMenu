using Microsoft.EntityFrameworkCore;
using FoodMenu.Models;

namespace FoodMenu.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodMenuIngridient>().HasKey(fmi => new
            {
                fmi.IngridientId,
                fmi.FoodId
            });

            modelBuilder.Entity<FoodMenuIngridient>().HasOne(f => f.Food).WithMany(fi => fi.FoodMenuIngridients).HasForeignKey(f => f.FoodId);
            modelBuilder.Entity<FoodMenuIngridient>().HasOne(f => f.Ingridient).WithMany(fi => fi.FoodMenuIngridients).HasForeignKey(f => f.IngridientId);

            modelBuilder.Entity<Food>().HasData(
                new Food
                {
                    Id = 1,
                    Name = "Margaritta",
                    Price = 23.50,
                    ImageUrl = string.Empty
                });

            modelBuilder.Entity<Ingridient>().HasData(
                new Ingridient
                {
                    Id = 1,
                    Name = "Sauce",
                },
                new Ingridient
                {
                    Id = 2,
                    Name = "Cheese",
                });

            modelBuilder.Entity<FoodMenuIngridient>().HasData(
                new FoodMenuIngridient
                {
                    FoodId = 1,
                    IngridientId = 1,
                },
                new FoodMenuIngridient
                {
                    FoodId = 1,
                    IngridientId = 2,
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodMenuIngridient> FoodMenuIngridients { get; set; }
    }
}
