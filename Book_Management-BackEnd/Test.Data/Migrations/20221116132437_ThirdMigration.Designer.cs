﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Data;

#nullable disable

namespace Test.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20221116132437_ThirdMigration")]
    partial class ThirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Test.Data.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BookID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("BookName");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Description");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("Price");

                    b.Property<DateTime>("PublishingYear")
                        .HasMaxLength(500)
                        .HasColumnType("Date")
                        .HasColumnName("PublishingYear");

                    b.HasKey("BookId");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("Test.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProcessedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("RequestByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessedByUserId");

                    b.HasIndex("RequestByUserId");

                    b.ToTable("BookBorrowingRequest", (string)null);
                });

            modelBuilder.Entity("Test.Data.Entities.BookBorrowingRequestDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookBorrowingRequestId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookBorrowingRequestId");

                    b.HasIndex("BookId");

                    b.ToTable("BookBorrowingRequestDetails", (string)null);
                });

            modelBuilder.Entity("Test.Data.Entities.BookInCategory", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BookInCategories", (string)null);
                });

            modelBuilder.Entity("Test.Data.Entities.Category", b =>
                {
                    b.Property<int?>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("CategoryName");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Test.Data.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Test.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.HasOne("Test.Data.Entities.User", "ProcessedBy")
                        .WithMany("ProcessedRequests")
                        .HasForeignKey("ProcessedByUserId");

                    b.HasOne("Test.Data.Entities.User", "RequestedBy")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("RequestByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessedBy");

                    b.Navigation("RequestedBy");
                });

            modelBuilder.Entity("Test.Data.Entities.BookBorrowingRequestDetails", b =>
                {
                    b.HasOne("Test.Data.Entities.BookBorrowingRequest", "BookBorrowingRequest")
                        .WithMany("Details")
                        .HasForeignKey("BookBorrowingRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Data.Entities.Book", "Book")
                        .WithMany("Details")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookBorrowingRequest");
                });

            modelBuilder.Entity("Test.Data.Entities.BookInCategory", b =>
                {
                    b.HasOne("Test.Data.Entities.Book", "Book")
                        .WithMany("BookInCategories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Data.Entities.Category", "Category")
                        .WithMany("BookInCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Test.Data.Entities.Book", b =>
                {
                    b.Navigation("BookInCategories");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("Test.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Test.Data.Entities.Category", b =>
                {
                    b.Navigation("BookInCategories");
                });

            modelBuilder.Entity("Test.Data.Entities.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");

                    b.Navigation("ProcessedRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
