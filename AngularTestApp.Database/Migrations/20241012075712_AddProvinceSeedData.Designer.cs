﻿// <auto-generated />
using AngularTestApp.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AngularTestApp.Database.Migrations
{
    [DbContext(typeof(AngularTestAppDbContext))]
    [Migration("20241012075712_AddProvinceSeedData")]
    partial class AddProvinceSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AngularTestApp.Database.Entities.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Country 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Country 2"
                        });
                });

            modelBuilder.Entity("AngularTestApp.Database.Entities.ProvinceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 2,
                            Name = "Province 2.1"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Name = "Province 2.2"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "Province 2.3"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 1,
                            Name = "Province 1.1"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 1,
                            Name = "Province 1.2"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 1,
                            Name = "Province 1.3"
                        });
                });

            modelBuilder.Entity("AngularTestApp.Database.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AngularTestApp.Database.Entities.ProvinceEntity", b =>
                {
                    b.HasOne("AngularTestApp.Database.Entities.CountryEntity", "Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AngularTestApp.Database.Entities.UserEntity", b =>
                {
                    b.HasOne("AngularTestApp.Database.Entities.CountryEntity", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AngularTestApp.Database.Entities.ProvinceEntity", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("AngularTestApp.Database.Entities.CountryEntity", b =>
                {
                    b.Navigation("Provinces");
                });
#pragma warning restore 612, 618
        }
    }
}
