﻿// <auto-generated />
using Butcher_Shop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Butcher_Shop.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

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

            modelBuilder.Entity("Butcher_Shop.Models.StorageArticle", b =>
                {
                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("StorageId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("StorageArticles");
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

            modelBuilder.Entity("Butcher_Shop.Models.Storage", b =>
                {
                    b.HasOne("Butcher_Shop.Models.ButcherStore", "ButcherStore")
                        .WithMany()
                        .HasForeignKey("ButcherStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ButcherStore");
                });

            modelBuilder.Entity("Butcher_Shop.Models.StorageArticle", b =>
                {
                    b.HasOne("Butcher_Shop.Models.Article", "Article")
                        .WithMany("StorageArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Butcher_Shop.Models.Storage", "Storage")
                        .WithMany("StorageArticles")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Article", b =>
                {
                    b.Navigation("StorageArticles");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Butcher", b =>
                {
                    b.Navigation("ButcherStores");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Storage", b =>
                {
                    b.Navigation("StorageArticles");
                });
#pragma warning restore 612, 618
        }
    }
}
