﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMS.HealthCare.HeartRate.Data;

#nullable disable

namespace PMS.HealthCare.Migrations
{
    [DbContext(typeof(ResponseDataDbContext))]
    [Migration("20240109090614_DbInit1")]
    partial class DbInit1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PMS.HealthCare.HeartRate.Models.ResponseData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Completed")
                        .HasMaxLength(100)
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Spotify", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Completed = true,
                            Title = "Conan"
                        },
                        new
                        {
                            Id = 2,
                            Completed = false,
                            Title = "Bảy viên ngọc rồng"
                        },
                        new
                        {
                            Id = 3,
                            Completed = true,
                            Title = "Shin Cậu Bé Bút Chì"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}