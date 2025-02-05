﻿// <auto-generated />
using System;
using Infrastrucure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastrucure.Migrations
{
    [DbContext(typeof(RestaurantsDbContext))]
    [Migration("20250203152436_UpdateRestaurantOwner")]
    partial class UpdateRestaurantOwner
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4298),
                            Name = "Menu 1",
                            Price = 10.00m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4300),
                            Name = "Menu 2",
                            Price = 20.00m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4301),
                            Name = "Menu 3",
                            Price = 30.00m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4303),
                            Name = "Menu 4",
                            Price = 40.00m,
                            RestaurantId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4291),
                            Name = "Restaurant 1",
                            OwnerId = "ed2029f6-757d-463f-88a3-3ed4133a50e0",
                            Phone = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4293),
                            Name = "Restaurant 2",
                            OwnerId = "ed2029f6-757d-463f-88a3-3ed4133a50e0",
                            Phone = "1234567590"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Menu", b =>
                {
                    b.HasOne("Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Menus")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Domain.Entities.Restaurant", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
