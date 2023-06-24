﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaGoAPI.DBContext;

#nullable disable

namespace PizzaGoAPI.Migrations
{
    [DbContext(typeof(PizzaAppContext))]
    [Migration("20230624062145_updateSeedData")]
    partial class updateSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaGoAPI.Entities.AddedIngridient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AddedIngridients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Халапенью",
                            Price = 59
                        },
                        new
                        {
                            Id = 2,
                            Name = "Сыр",
                            Price = 29
                        },
                        new
                        {
                            Id = 3,
                            Name = "Кетчуп",
                            Price = 19
                        });
                });

            modelBuilder.Entity("PizzaGoAPI.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Пицца"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Десерт"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Напиток"
                        });
                });

            modelBuilder.Entity("PizzaGoAPI.Entities.CategorySize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategorySizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 25.0,
                            CategoryId = 1,
                            Name = "Маленькая"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 30.0,
                            CategoryId = 1,
                            Name = "Средняя"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 35.0,
                            CategoryId = 1,
                            Name = "Большая"
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 100.0,
                            CategoryId = 2,
                            Name = "Маленький кусочек"
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 250.0,
                            CategoryId = 2,
                            Name = "Большой кусочек"
                        },
                        new
                        {
                            Id = 6,
                            Capacity = 0.33000000000000002,
                            CategoryId = 3,
                            Name = "Маленький"
                        },
                        new
                        {
                            Id = 7,
                            Capacity = 0.5,
                            CategoryId = 3,
                            Name = "Средний"
                        },
                        new
                        {
                            Id = 8,
                            Capacity = 1.0,
                            CategoryId = 3,
                            Name = "Большой"
                        });
                });

            modelBuilder.Entity("PizzaGoAPI.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Some description of peperonni",
                            Name = "Пепперони",
                            Price = 200
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Some description of pizza with pineaple",
                            Name = "С ананасами",
                            Price = 250
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Some description of carbonara",
                            Name = "Карбонара",
                            Price = 220
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Very unusual cake",
                            Name = "Шоколадный чизкейк",
                            Price = 50
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "Some Cocktail",
                            Name = "Молочный коктейль",
                            Price = 30
                        });
                });

            modelBuilder.Entity("PizzaGoAPI.Entities.CategorySize", b =>
                {
                    b.HasOne("PizzaGoAPI.Entities.Category", "Category")
                        .WithMany("CategorySizes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PizzaGoAPI.Entities.Product", b =>
                {
                    b.HasOne("PizzaGoAPI.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PizzaGoAPI.Entities.Category", b =>
                {
                    b.Navigation("CategorySizes");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
