﻿// <auto-generated />
using System;
using Butcher_Shop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Butcher_Shop.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210528110613_ButcherStoreHasStorages")]
    partial class ButcherStoreHasStorages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Butcher_Shop.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StorageId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Butcher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Butchers");
                });

            modelBuilder.Entity("Butcher_Shop.Models.ButcherStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int>("ButcherId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("ButcherId");

                    b.ToTable("ButcherStores");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("ButcherStoreId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ButcherStoreId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("ButcherStoreId")
                        .HasColumnType("int");

                    b.Property<int>("Job")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ButcherStoreId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int>("ButcherStoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ButcherStoreId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Article", b =>
                {
                    b.HasOne("Butcher_Shop.Models.Customer", null)
                        .WithMany("BoughtArticles")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Butcher_Shop.Models.Storage", "Storage")
                        .WithMany("Articles")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("Butcher_Shop.Models.ButcherStore", b =>
                {
                    b.HasOne("Butcher_Shop.Models.Butcher", "Butcher")
                        .WithMany("ButcherStores")
                        .HasForeignKey("ButcherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Butcher");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Customer", b =>
                {
                    b.HasOne("Butcher_Shop.Models.ButcherStore", null)
                        .WithMany("Customers")
                        .HasForeignKey("ButcherStoreId");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Employee", b =>
                {
                    b.HasOne("Butcher_Shop.Models.ButcherStore", null)
                        .WithMany("Employees")
                        .HasForeignKey("ButcherStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Butcher_Shop.Models.Storage", b =>
                {
                    b.HasOne("Butcher_Shop.Models.ButcherStore", "ButcherStore")
                        .WithMany("Storages")
                        .HasForeignKey("ButcherStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ButcherStore");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Butcher", b =>
                {
                    b.Navigation("ButcherStores");
                });

            modelBuilder.Entity("Butcher_Shop.Models.ButcherStore", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Employees");

                    b.Navigation("Storages");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Customer", b =>
                {
                    b.Navigation("BoughtArticles");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Storage", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
