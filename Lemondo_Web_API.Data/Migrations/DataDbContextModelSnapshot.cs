﻿// <auto-generated />
using System;
using Lemondo_Web_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lemondo_Web_API.Data.Migrations
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Lemondo_Web_API.Domain.Statement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatementDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatementDetailId");

                    b.ToTable("Statements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatementDetailId = 1,
                            Title = "Phil Murphy "
                        },
                        new
                        {
                            Id = 2,
                            StatementDetailId = 2,
                            Title = "Phil Murphy "
                        },
                        new
                        {
                            Id = 3,
                            StatementDetailId = 3,
                            Title = "Phil Murphy "
                        },
                        new
                        {
                            Id = 4,
                            StatementDetailId = 4,
                            Title = "Phil Murphy "
                        },
                        new
                        {
                            Id = 5,
                            StatementDetailId = 5,
                            Title = "Phil Murphy "
                        });
                });

            modelBuilder.Entity("Lemondo_Web_API.Domain.StatementDetail", b =>
                {
                    b.Property<int>("StatementDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatementDetailId");

                    b.ToTable("StatementDetails");

                    b.HasData(
                        new
                        {
                            StatementDetailId = 1,
                            Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.",
                            PhoneNumber = "+995 556 52 26 36"
                        },
                        new
                        {
                            StatementDetailId = 2,
                            Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.",
                            PhoneNumber = "+995 556 52 26 36"
                        },
                        new
                        {
                            StatementDetailId = 3,
                            Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.",
                            PhoneNumber = "+995 556 52 26 36"
                        },
                        new
                        {
                            StatementDetailId = 4,
                            Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.",
                            PhoneNumber = "+995 556 52 26 36"
                        },
                        new
                        {
                            StatementDetailId = 5,
                            Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.",
                            PhoneNumber = "+995 556 52 26 36"
                        });
                });

            modelBuilder.Entity("Lemondo_Web_API.Domain.Statement", b =>
                {
                    b.HasOne("Lemondo_Web_API.Domain.StatementDetail", "StatementDetail")
                        .WithMany()
                        .HasForeignKey("StatementDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatementDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
