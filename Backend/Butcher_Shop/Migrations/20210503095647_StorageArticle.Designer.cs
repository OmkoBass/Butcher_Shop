// <auto-generated />
using Butcher_Shop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Butcher_Shop.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210503095647_StorageArticle")]
    partial class StorageArticle
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

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Article");
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
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

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

                    b.ToTable("Storage");
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

                    b.ToTable("StorageArticle");
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
                        .WithMany("Storages")
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

            modelBuilder.Entity("Butcher_Shop.Models.ButcherStore", b =>
                {
                    b.Navigation("Storages");
                });

            modelBuilder.Entity("Butcher_Shop.Models.Storage", b =>
                {
                    b.Navigation("StorageArticles");
                });
#pragma warning restore 612, 618
        }
    }
}
