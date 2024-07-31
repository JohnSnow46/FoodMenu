﻿// <auto-generated />
using System;
using FoodMenu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodMenu.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodMenu.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FoodMenuIngridientFoodId")
                        .HasColumnType("int");

                    b.Property<int?>("FoodMenuIngridientIngridientId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FoodMenuIngridientIngridientId", "FoodMenuIngridientFoodId");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "",
                            Name = "Margaritta",
                            Price = 23.5
                        });
                });

            modelBuilder.Entity("FoodMenu.Models.FoodMenuIngridient", b =>
                {
                    b.Property<int>("IngridientId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("IngridientId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodMenuIngridients");

                    b.HasData(
                        new
                        {
                            IngridientId = 1,
                            FoodId = 1
                        },
                        new
                        {
                            IngridientId = 2,
                            FoodId = 1
                        });
                });

            modelBuilder.Entity("FoodMenu.Models.Ingridient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FoodMenuIngridientFoodId")
                        .HasColumnType("int");

                    b.Property<int?>("FoodMenuIngridientIngridientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FoodMenuIngridientIngridientId", "FoodMenuIngridientFoodId");

                    b.ToTable("Ingridients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sauce"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cheese"
                        });
                });

            modelBuilder.Entity("FoodMenu.Models.Food", b =>
                {
                    b.HasOne("FoodMenu.Models.FoodMenuIngridient", null)
                        .WithMany("FoodMenus")
                        .HasForeignKey("FoodMenuIngridientIngridientId", "FoodMenuIngridientFoodId");
                });

            modelBuilder.Entity("FoodMenu.Models.FoodMenuIngridient", b =>
                {
                    b.HasOne("FoodMenu.Models.Food", "Food")
                        .WithMany("FoodMenuIngridients")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodMenu.Models.Ingridient", "Ingridient")
                        .WithMany("FoodMenuIngridients")
                        .HasForeignKey("IngridientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Ingridient");
                });

            modelBuilder.Entity("FoodMenu.Models.Ingridient", b =>
                {
                    b.HasOne("FoodMenu.Models.FoodMenuIngridient", null)
                        .WithMany("Ingridients")
                        .HasForeignKey("FoodMenuIngridientIngridientId", "FoodMenuIngridientFoodId");
                });

            modelBuilder.Entity("FoodMenu.Models.Food", b =>
                {
                    b.Navigation("FoodMenuIngridients");
                });

            modelBuilder.Entity("FoodMenu.Models.FoodMenuIngridient", b =>
                {
                    b.Navigation("FoodMenus");

                    b.Navigation("Ingridients");
                });

            modelBuilder.Entity("FoodMenu.Models.Ingridient", b =>
                {
                    b.Navigation("FoodMenuIngridients");
                });
#pragma warning restore 612, 618
        }
    }
}
