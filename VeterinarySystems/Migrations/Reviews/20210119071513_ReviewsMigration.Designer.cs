﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeterinarySystems.Data.Review;

namespace VeterinarySystems.Migrations.Reviews
{
    [DbContext(typeof(ReviewsContext))]
    [Migration("20210119071513_ReviewsMigration")]
    partial class ReviewsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VeterinarySystems.Model.Reviews", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("StarRatings")
                        .HasColumnType("int");

                    b.Property<int>("WrittenBy")
                        .HasColumnType("int");

                    b.Property<int>("WrittenFor")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.ToTable("CustomerReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
