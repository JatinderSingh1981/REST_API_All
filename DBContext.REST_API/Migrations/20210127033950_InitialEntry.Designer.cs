﻿// <auto-generated />
using System;
using DBContext.REST_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBContext.REST_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210127033950_InitialEntry")]
    partial class InitialEntry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Common.REST_API.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "HP"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dell"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lenovo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Microsoft"
                        });
                });

            modelBuilder.Entity("Common.REST_API.FormFactor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FormFactor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "MidTower"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tower"
                        });
                });

            modelBuilder.Entity("Common.REST_API.ProcessorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProcessorType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "i3"
                        },
                        new
                        {
                            Id = 2,
                            Name = "i5"
                        },
                        new
                        {
                            Id = 3,
                            Name = "i7"
                        },
                        new
                        {
                            Id = 4,
                            Name = "i9"
                        });
                });

            modelBuilder.Entity("Common.REST_API.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Desktop"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Laptop"
                        });
                });

            modelBuilder.Entity("Entities.REST_API.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComputerTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProcessorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RamSlots")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("USBPorts")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            BrandId = 2,
                            ComputerTypeId = 1,
                            Description = "Added the Desktop product through Seeding",
                            ProcessorId = 1,
                            Quantity = 100,
                            RamSlots = 4,
                            USBPorts = 3
                        },
                        new
                        {
                            ProductId = 2,
                            BrandId = 1,
                            ComputerTypeId = 2,
                            Description = "Added the Laptop product through Seeding",
                            ProcessorId = 2,
                            Quantity = 50,
                            RamSlots = 2,
                            USBPorts = 3
                        });
                });

            modelBuilder.Entity("Entities.REST_API.ProductDesktop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FormFactorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Desktops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FormFactorId = 1,
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("Entities.REST_API.ProductLaptop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScreenSize")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Laptops");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            ScreenSize = 15
                        });
                });

            modelBuilder.Entity("Entities.REST_API.ProductDesktop", b =>
                {
                    b.HasOne("Entities.REST_API.Product", "Product")
                        .WithOne("ProductDesktop")
                        .HasForeignKey("Entities.REST_API.ProductDesktop", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.REST_API.ProductLaptop", b =>
                {
                    b.HasOne("Entities.REST_API.Product", "Product")
                        .WithOne("ProductLaptop")
                        .HasForeignKey("Entities.REST_API.ProductLaptop", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.REST_API.Product", b =>
                {
                    b.Navigation("ProductDesktop");

                    b.Navigation("ProductLaptop");
                });
#pragma warning restore 612, 618
        }
    }
}
